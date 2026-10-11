/*
Rules: E19-5-inherited-members
Authority: ECMA-334 7th ed 19.5
Version: 7.3
Expected: run
Stdout: OK 0
Mutate: Code.Mark.Equals(Code.Mark)
Into: Code.Mark.Unavailable(Code.Mark)
*/
using System;
enum Code { Mark }
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        // Only the availability of an inherited member is specified here.
        bool result = Code.Mark.Equals(Code.Mark);
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
