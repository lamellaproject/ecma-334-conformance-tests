/*
Rules: E19-2-default-int
Authority: ECMA-334 7th ed 19.2
Version: 7.3
Expected: run
Stdout: OK 2
Mutate: enum Counter
Into: enum Counter : long
*/
using System;
enum Counter { Large = 2147483647 }
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        int difference = Counter.Large - (Counter)2147483646;
        Check(difference == 1, "subtraction-result-is-int");
        Check(unchecked((Counter)4294967296L) == (Counter)0, "default-int-width");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
