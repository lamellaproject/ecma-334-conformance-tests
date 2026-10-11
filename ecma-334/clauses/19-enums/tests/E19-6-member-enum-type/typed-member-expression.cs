/*
Rules: E19-6-member-enum-type; E19-6-member-cast-value
Authority: ECMA-334 7th ed 19.6
Version: 7.3
Expected: run
Stdout: OK 2
Mutate: Code member = Code.Mark
Into: Code member = (Code)0
*/
using System;
enum Code : ushort { Mark = 37 }
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static int Pick(Code item) { return 1; }
    static int Pick(ushort item) { return 2; }
    static void Main()
    {
        Code member = Code.Mark;
        Check(Pick(Code.Mark) == 1, "member-expression-has-enum-type");
        Check(member == (Code)37, "member-value-is-cast-associated-value");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
