using System;
using System.Collections.Generic;
using System.Linq;

namespace GameOfLife.Lib {
  public class CellBuilder {
    Rule Rule { get; }

    // 各セルに設定するルールをコンストラクタで受け取ります。
    public CellBuilder(Rule rule) => Rule = rule;

    // 縦横の長さと生きたセルの割合を受け取りグリッド（配列の配列）を返します。
    public Cell[][] BuildCells(int rowLength, int colLength, int percentOfLivingCells) {
      var random = new Random();
      var cells = Enumerable.Range(1, rowLength)
        .Select(_ => Enumerable.Range(1, colLength)
          .Select(__ => {
            var state = (random.Next(1, 100) < percentOfLivingCells)
              ? Cell.State.Alive
              : Cell.State.Dead;
            return new Cell(state, Rule);
          }).ToArray()
        ).ToArray();
      return ConnectNeighbours(cells);
    }
    // 各セルに周囲のセルを接続します。
    Cell[][] ConnectNeighbours(Cell[][] cells) {
      foreach (var (row, rowIndex) in cells.Select((row, i) => (row, i))) {
        foreach (var (cell, colIndex) in row.Select((cell, i) => (cell, i))) {
          foreach (Cell neighbour in GetNeighbours(rowIndex, colIndex, cells.Length, row.Length))
            cell.AddNeighbour(neighbour);
        }
      }
      return cells;
      // 周囲のセルを取得します。ローカル関数です。
      IEnumerable<Cell> GetNeighbours(int rowIndex, int colIndex, int rowLength, int colLength) {
        for (int i = -1; i < 2; i++) {
          for (int j = -1; j < 2; j++) {
            if (i == 0 && j == 0)
              continue;
            int offsetRow = circlate(rowIndex + i, rowLength);
            int offsetCol = circlate(colIndex + j, colLength);
            yield return cells[offsetRow][offsetCol];
          }
        }
      }
    }

    // はみ出るインデクスを循環させます。(C#ではマイナスのインデクスで配列の後ろからn番目でアクセスができない)
    // 周囲のセルを取得する際にグリッド端のセルはハミ出るのでこれで逆の端と繋げます。
    int circlate(int index, int length) {
      if (index < 0)
        return index + length;
      if (index >= length)
        return index - length;
      else
        return index;
    }
  }
}