/*
Rules: E6-4-4-var-declared-type-precedence
Authority: ECMA-334 7th ed 6.4.4
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: var value = 13;
Into: int value = 13;
*/
using System;
class var
{
    public int Number;
    public static implicit operator var(int input) { return new var { Number = input }; }
}
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        var value = 13;
        Check(value.Number == 13, "declared-var-precedes-inference");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
