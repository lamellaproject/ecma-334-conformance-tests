/*
Rules: E19-4-shared-value
Authority: ECMA-334 7th ed 19.4
Version: 7.3
Expected: run
Stdout: OK 2
Mutate: Second = 19
Into: Second = 20
*/
using System;
enum Code { First = 19, Second = 19 }
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Check(Code.First == Code.Second, "different-names-same-value");
        Check((int)Code.Second == 19, "shared-associated-value");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
