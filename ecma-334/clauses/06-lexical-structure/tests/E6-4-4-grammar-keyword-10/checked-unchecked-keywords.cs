/*
Rules: E6-4-4-grammar-keyword-10; E6-4-4-grammar-keyword-70
Authority: ECMA-334 7th ed 6.4.4
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: int next = checked(maximum + 1);
Into: int next = unchecked(maximum + 1);
*/
using System;
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        int maximum = 2147483647;
        bool caught = false;
        try { int next = checked(maximum + 1); }
        catch (OverflowException) { caught = true; }
        int wrapped = unchecked(maximum + 1);
        Check(caught && wrapped == -2147483648, "checked-and-unchecked");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
