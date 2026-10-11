/*
Rules: E15-2-7-partial-multiple-parts
Authority: ECMA-334 7th ed 15.2.7
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: partial class Meter { public int Right = 41; }
Into: partial class Other { public int Right = 41; }
*/
using System;
partial class Meter { public int Left = 31; }
partial class Meter { public int Right = 41; }
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Meter value = new Meter();
        Check(value.Left + value.Right == 72, "class-parts-merge");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
