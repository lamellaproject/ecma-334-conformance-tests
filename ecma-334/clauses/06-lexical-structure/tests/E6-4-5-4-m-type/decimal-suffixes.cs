/*
Rules: E6-4-5-4-m-type; E6-4-5-4-grammar-real-type-suffix-5; E6-4-5-4-grammar-real-type-suffix-6
Authority: ECMA-334 7th ed 6.4.5.4
Version: 7.3
Expected: run
Stdout: OK 3
Mutate: Tag(23M)
Into: Tag(23D)
*/
using System;
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static int Tag(decimal value) { return 1; }
    static int Tag(double value) { return 2; }
    static void Main()
    {
        Check(Tag(23M) == 1, "upper-m-type");
        Check(Tag(.875m) == 1, "lower-m-type");
        Check(.875m == 875m / 1000m, "decimal-value");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
