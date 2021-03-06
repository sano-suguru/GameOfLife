﻿using GameOfLife.Lib;
using System;
using System.IO;

namespace GameOfLife.ConsoleApp {
  public class ConsoleDrawer {
    TextWriter StdOut { get; }

    // TextWriterは外部からDIします。
    public ConsoleDrawer(TextWriter writer) => StdOut = writer;

    // グリッドをTextWriter.Flushで一気に出力します。
    public void DrawCells(Cell[][] cells) {
      Console.CursorTop = 0;
      Console.CursorLeft = 0;
      foreach (var row in cells) {
        foreach (var cell in row) {
          StdOut.Write(cell);
        }
        StdOut.WriteLine();
      }
      StdOut.Flush();
    }
  }
}