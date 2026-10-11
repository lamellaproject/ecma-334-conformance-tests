/*
Rules: E12-8-16-5-multidimensional-inference-set; E12-8-16-5-best-common-element-type; E12-8-16-5-implicit-type-initializer-form
Authority: ECMA-334 7th ed 12.8.16.5
Version: 7.3
Expected: run
Stdout: OK 2
Mutate: new[,] { { (short)4, (short)7 }, { (short)9, 14L } }
Into: new[,] { { (short)4, (short)7 }, { (short)9, 14 } }
*/
using System;
class Program
{
    static int Choose(long[,] value) { return 1; }
    static int Choose(int[,] value) { return 2; }
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        var cells = new[,] { { (short)4, (short)7 }, { (short)9, 14L } };
        Check(Choose(cells) == 1, "all-nested-expressions-infer-long");
        bool values = cells[0, 0] == 4 && cells[0, 1] == 7 && cells[1, 0] == 9 && cells[1, 1] == 14;
        Check(values, "nested-inferred-array-values");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
