﻿using System.Linq;

namespace GameOfLife.Lib {
  public class Grid {
    public Cell[][] Cells { get; }

    public Grid(Cell[][] cells) => Cells = cells;

    // セル達を次の世代へ進めます。
    public void ToNextGen() {
      var flattened = Cells.SelectMany(row => row);
      foreach (var cell in flattened)
        cell.SetNextState();
      foreach (var cell in flattened)
        cell.ToNextGen();
    }
  }
}