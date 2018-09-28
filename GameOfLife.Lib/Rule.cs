using System;
using System.Collections.Generic;

namespace GameOfLife.Lib {
  public class Rule {
    internal Cell.State GetNextState(Cell.State self, IList<Cell> neighbours) => throw new NotImplementedException();
  }
}