/*
Rules: E12-8-16-5-explicit-dimensions-form; E12-8-16-5-explicit-result-type
Authority: ECMA-334 7th ed 12.8.16.5
Version: 7.3
Expected: run
Stdout: OK 2
Mutate: new int[2, 1] { { 7 }, { 19 } }
Into: new int[2, 1] { { 19 }, { 7 } }
*/
using System;
class Program
{
    static int Choose(int[,] value) { return 1; }
    static int Choose(object value) { return 2; }
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        var cells = new int[2, 1] { { 7 }, { 19 } };
        Check(Choose(cells) == 1, "explicit-rectangular-type");
        Check(cells[0, 0] == 7 && cells[1, 0] == 19, "explicit-dimensions-initializer");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
