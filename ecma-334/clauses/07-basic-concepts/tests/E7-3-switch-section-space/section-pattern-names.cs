/*
Rules: E7-3-switch-section-space; E7-3-disjoint-local-name-reuse
Authority: ECMA-334 7th ed 7.3
Version: 7.3
Expected: run
Stdout: OK 2
Mutate: case string piece:
Into: case string renamed:
*/
using System;
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static int Read(object value)
    {
        switch (value)
        {
            case int piece: return piece;
            case string piece: return piece.Length;
            default: return 0;
        }
    }
    static void Main()
    {
        Check(Read(17) == 17, "first-section-pattern-space");
        Check(Read("leaf") == 4, "second-section-pattern-space");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
