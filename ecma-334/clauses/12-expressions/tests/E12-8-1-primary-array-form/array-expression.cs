/*
Rules: E12-8-1-primary-array-form
Authority: ECMA-334 7th ed 12.8.1
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: new int[] { 3, 8 }
Into: new int[] { 5, 9 }
*/
using System;
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        int[] result = new int[] { 3, 8 };
        Check(result.Length == 2 && result[0] == 3 && result[1] == 8, "array-creation-is-primary-expression");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
