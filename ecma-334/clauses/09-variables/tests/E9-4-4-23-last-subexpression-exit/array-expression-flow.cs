/*
Rules: E9-4-4-23-last-subexpression-exit; E9-4-4-23-embedded-expression-scope; E9-4-4-23-fixed-subexpression-order; E9-4-4-23-first-subexpression-entry; E9-4-4-23-later-subexpression-entry
Authority: ECMA-334 7th ed 9.4.4.23
Version: 7.3
Expected: run
Stdout: OK 4
Mutate: Select(cells, out slot)[slot]
Into: Select(cells, out sink)[slot]
*/
using System;
class Program
{
    static int checks, failures, trace, sink;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static int[] Select(int[] source, out int index) { trace = trace * 10 + 1; index = 1; return source; }
    static int Mark(int digit, int value) { trace = trace * 10 + digit; return value; }
    static int Count(int value) { return value; }
    static void Main()
    {
        int[] cells = { 26, 44, 62 };
        int slot;
        int item = Select(cells, out slot)[slot];
        Check(item == 44 && slot == 1 && trace == 1, "receiver-to-index");
        trace = 0;
        int index;
        int sum = Select(cells, out sink)[index = Mark(2, 2)] += Mark(3, index + 5);
        Check(sum == 69 && cells[2] == 69 && index == 2 && trace == 123, "index-to-compound-right");
        int width;
        int[] line = new int[width = Count(5)];
        Check(line.Length == width && width == 5, "dimension-to-array-exit");
        int rows, columns;
        int[,] grid = new int[rows = Count(3), columns = rows + Count(1)];
        Check(rows == 3 && columns == 4 && grid.Length == 12, "dimension-to-dimension-and-exit");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
