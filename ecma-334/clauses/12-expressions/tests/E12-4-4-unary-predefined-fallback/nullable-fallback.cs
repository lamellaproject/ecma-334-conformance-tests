/*
Rules: E12-4-4-unary-predefined-fallback; E12-4-5-binary-predefined-fallback; E12-4-6-object-empty
Authority: ECMA-334 7th ed 12.4.4
Version: 7.3
Expected: run
Stdout: OK 2
Mutate: int? first = -value;
Into: int? first = +value;
*/
using System;
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        int? value = 8; int? first = -value; int? second = value + 5;
        Check(first == -8 && second == 13, "predefined-lifted-fallback");
        object left = new object(), right = left;
        Check(left == right, "object-empty-user-candidate-set");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
