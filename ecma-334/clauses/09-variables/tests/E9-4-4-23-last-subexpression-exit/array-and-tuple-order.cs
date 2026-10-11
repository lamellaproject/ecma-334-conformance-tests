/*
Rules: E9-4-4-23-last-subexpression-exit; E9-4-4-23-embedded-expression-scope; E9-4-4-23-fixed-subexpression-order; E9-4-4-23-first-subexpression-entry; E9-4-4-23-later-subexpression-entry
Authority: ECMA-334 7th ed 9.4.4.23
Version: 7.3
Expected: run
Stdout: OK 5
Mutate: (cell = Mark(1, 3), Mark(2, cell))
Into: (Mark(2, cell), cell = Mark(1, 3))
*/
using System;
class Program
{
    static int checks, failures, trace;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static int Mark(int digit, int value) { trace = trace * 10 + digit; return value; }
    static int[] Cells(int[] cells) { trace = trace * 10 + 1; return cells; }
    static void Main()
    {
        int cell;
        trace = 0;
        var pair = (cell = Mark(1, 3), Mark(2, cell));
        Check(pair.Item1 == 3 && pair.Item2 == 3 && cell == 3 && trace == 12, "tuple-operand-transfer");
        int[] cells = { 7, 11 };
        trace = 0;
        int element = Cells(cells)[cell = Mark(2, 1)];
        Check(element == 11 && cell == 1 && trace == 12, "array-receiver-before-index");
        trace = 0;
        int compound = Cells(cells)[cell = Mark(2, 1)] += Mark(3, cell + 2);
        Check(compound == 14 && cells[1] == 14 && cell == 1 && trace == 123, "compound-assignment-transfer");
        int size;
        int[] created = new int[size = 4];
        Check(created.Length == size && size == 4, "array-size-assignment-exit");
        int row, column;
        int[,] grid = new int[row = 2, column = row + 1];
        Check(grid.Length == 6 && row == 2 && column == 3, "array-creation-dimensions-transfer");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
