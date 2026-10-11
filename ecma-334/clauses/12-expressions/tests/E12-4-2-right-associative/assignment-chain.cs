/*
Rules: E12-4-2-right-associative
Authority: ECMA-334 7th ed 12.4.2
Version: 7.3
Expected: run
Stdout: OK 2
Mutate: a = b = 19
Into: (a = b) = 19
*/
using System;
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        int a = 7, b = 11; int result = a = b = 19;
        Check(result == 19 && a == 19 && b == 19, "right-associative-assignment");
        bool first = false, second = true;
        int choice = first ? 1 : second ? 2 : 3;
        Check(choice == 2, "right-associative-conditional");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
