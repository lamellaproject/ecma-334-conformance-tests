/*
Rules: E19-4-forward-value-reference; E19-4-initializer-member-type
Authority: ECMA-334 7th ed 19.4
Version: 7.3
Expected: run
Stdout: OK 3
Mutate: Early = Late - 2
Into: Early = Late + 2
*/
using System;
enum Code : byte { Early = Late - 2, Late = 15, Following }
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Check((byte)Code.Early == 13, "forward-value-reference");
        Check((byte)Code.Late == 15, "later-associated-value");
        Check((byte)Code.Following == 16, "textual-predecessor-used");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
