/*
Rules: E6-4-6-grammar-operator-or-punctuator-31
Authority: ECMA-334 7th ed 6.4.6
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: pointer->Count
Into: pointer.Count
*/
using System;
struct Point { public int Count; }
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static unsafe void Main()
    {
        Point point;
        point.Count = 17;
        Point* pointer = &point;
        int actual = pointer->Count;
        Check(actual == 17, "pointer-arrow");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
