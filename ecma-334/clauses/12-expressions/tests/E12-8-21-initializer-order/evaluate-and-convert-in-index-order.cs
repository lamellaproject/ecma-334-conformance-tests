/*
Rules: E12-8-21-initializer-order; E12-8-21-initialized-form; E12-8-21-initializer-form; E12-8-21-element-list-form; E12-8-21-element-form
Authority: ECMA-334 7th ed 12.8.21
Version: 7.3
Expected: run
Stdout: OK 4
Mutate: { Next(1), Next(2), }
Into: { Next(2), Next(1), }
*/
using System;
struct Cell { public int Number; }
struct Token
{
    public int Number;
    public static implicit operator Cell(Token value)
    {
        Program.trace = Program.trace * 10 + value.Number + 2;
        return new Cell { Number = value.Number * 4 + 3 };
    }
}
class Program
{
    static int checks, failures;
    public static int trace;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static Token Next(int number) { trace = trace * 10 + number; return new Token { Number = number }; }
    static void Main()
    {
        Span<Cell> cells = stackalloc Cell[2] { Next(1), Next(2), };
        Check(trace == 1324, "evaluate-convert-before-next-element");
        Check(cells.Length == 2, "explicit-initialized-length");
        Check(cells[0].Number == 7, "first-converted-item");
        Check(cells[1].Number == 11, "second-converted-item");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
