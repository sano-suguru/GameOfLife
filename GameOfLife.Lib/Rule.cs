﻿using System.Collections.Generic;
using System.Linq;

namespace GameOfLife.Lib {
  public class Rule {
    // 周囲の生きているセルの数から次代の生死を判定する
    internal Cell.State GetNextState(Cell.State self, IList<Cell> neighbours) {
      int alives = neighbours.Count(cell => cell.Current == Cell.State.Alive);
      bool willBorn = alives == 3;
      bool isSurvive = alives == 2 && self == Cell.State.Alive;
      return (willBorn || isSurvive) ? Cell.State.Alive : Cell.State.Dead;
    }
  }
}