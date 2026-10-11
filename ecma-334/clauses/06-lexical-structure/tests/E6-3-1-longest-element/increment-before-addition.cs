/*
Rules: E6-3-1-longest-element
Authority: ECMA-334 7th ed 6.3.1
Version: 7.3
Expected: run
Stdout: OK 3
Mutate: left+++right
Into: left+ ++right
*/
using System;
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        int left = 8, right = 3;
        int total = left+++right;
        Check(total == 11, "postincrement-value");
        Check(left == 9, "left-incremented");
        Check(right == 3, "right-unchanged");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
