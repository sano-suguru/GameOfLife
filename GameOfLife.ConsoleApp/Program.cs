﻿using GameOfLife.Lib;
using System;
using System.IO;
using System.Text;
using System.Threading;

namespace GameOfLife.ConsoleApp {
  class Program {
    static void Main(string[] args) {
      var rule = new Rule();
      var builder = new CellBuilder(rule);
      var cells = builder.BuildCells(
        rowLength: 20,
        colLength: 20,
        percentOfLivingCells: 30);
      var grid = new Grid(cells);
      var writer = new StreamWriter(Console.OpenStandardOutput(), Encoding.ASCII);
      var drawer = new ConsoleDrawer(writer);
      while (!Console.KeyAvailable) {
        drawer.DrawCells(grid.Cells);
        grid.ToNextGen();
        Thread.Sleep(200);
      }
    }
  }
}