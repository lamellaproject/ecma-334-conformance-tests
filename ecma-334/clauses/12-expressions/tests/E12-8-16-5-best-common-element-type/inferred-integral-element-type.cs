/*
Rules: E12-8-16-5-best-common-element-type; E12-8-16-5-implicit-type-initializer-form
Authority: ECMA-334 7th ed 12.8.16.5
Version: 7.3
Expected: run
Stdout: OK 2
Mutate: new[] { (short)7, 19 }
Into: new[] { (short)7, 19L }
*/
using System;
class Program
{
    static int Choose(int[] value) { return 1; }
    static int Choose(long[] value) { return 2; }
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        var cells = new[] { (short)7, 19 };
        Check(Choose(cells) == 1, "best-common-int-type");
        Check(cells.Length == 2 && cells[0] == 7 && cells[1] == 19, "inferred-array-values");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
