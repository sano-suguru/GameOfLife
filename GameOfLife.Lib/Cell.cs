using System.Collections.Generic;

namespace GameOfLife.Lib {
  public class Cell {
    // 生死
    public enum State { Alive, Dead }

    // 現在の生死
    internal State Current { get; private set; }

    // 次の世代の生死
    State Next { get; set; }

    // 周囲のセル
    IList<Cell> Neighbours { get; }

    // 次の世代の生死を判定するルール
    Rule Rule { get; }

    // 初期状態を受け取る。ルールはDIします。
    public Cell(State state, Rule rule) {
      Current = state;
      Rule = rule;
      Neighbours = new List<Cell>();
    }

    // 次の世代の生死を設定します。
    internal void SetNextState() =>
        Next = Rule.GetNextState(self: Current, Neighbours);

    // 世代を進めます。
    internal void ToNextGen() => Current = Next;

    // 周囲のセルを設定します。
    internal void AddNeighbour(Cell neighbour) => Neighbours.Add(neighbour);

    // コンソール出力時の描画
    public override string ToString() => Current == State.Alive ? "o " : ". ";
  }
}