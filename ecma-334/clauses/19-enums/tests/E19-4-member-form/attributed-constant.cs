/*
Rules: E19-4-member-form; E19-4-member-list-form; E19-4-associated-constant; E19-4-explicit-value
Authority: ECMA-334 7th ed 19.4
Version: 7.3
Expected: run
Stdout: OK 2
Mutate: Current = Old + 4
Into: Current = Old + 5
*/
using System;
enum Code : byte { [Obsolete] Old = 6, Current = Old + 4 }
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        const byte associated = (byte)Code.Current;
        const Code named = Code.Old;
        Check(associated == 10, "constant-expression-associated-value");
        Check((byte)named == 6, "attributed-member-constant");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
