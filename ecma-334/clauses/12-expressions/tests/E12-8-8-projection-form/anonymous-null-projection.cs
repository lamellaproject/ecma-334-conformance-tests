/*
Rules: E12-8-8-projection-form; E12-8-8-projection-semantics
Authority: ECMA-334 7th ed 12.8.8
Version: 7.3
Expected: run
Stdout: OK 3
Mutate: new { full?.Number }
Into: new { empty?.Number }
*/
using System;
class Cell { public int Number { get { Program.reads++; return 83; } } }
class Program
{
    public static int reads;
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Cell full = new Cell(), empty = null;
        var first = new { full?.Number };
        var second = new { empty?.Number };
        Check(first.Number.HasValue && first.Number.Value == 83, "projection-infers-name-and-lifted-type");
        Check(!second.Number.HasValue, "null-projection-value");
        Check(reads == 1, "null-projection-skips-access");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
