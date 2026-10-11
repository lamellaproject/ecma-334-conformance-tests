/*
Rules: E12-8-21-allocation-size; E12-8-21-item-type; E12-8-21-span-memory-view
Authority: ECMA-334 7th ed 12.8.21
Version: 7.3
Expected: run
Stdout: OK 3
Mutate: stackalloc Cell[2]
Into: stackalloc Cell[1]
*/
using System;
struct Cell { public long Number; public byte Flag; }
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Span<Cell> cells = stackalloc Cell[2];
        Check(cells.Length == 2, "struct-item-count");
        if (cells.Length == 2)
        {
            cells[0] = new Cell { Number = 0x1122334455667788L, Flag = 3 };
            cells[1] = new Cell { Number = 0x7766554433221100L, Flag = 9 };
        }
        Check(cells.Length == 2 && cells[0].Number == 0x1122334455667788L && cells[0].Flag == 3, "first-complete-struct");
        Check(cells.Length == 2 && cells[1].Number == 0x7766554433221100L && cells[1].Flag == 9, "last-complete-struct-without-overlap");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
