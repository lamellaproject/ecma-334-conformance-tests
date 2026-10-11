/*
Rules: E12-6-2-3-optional-default
Authority: ECMA-334 7th ed 12.6.2.3
Version: 7.3
Expected: run
Stdout: OK 3
Mutate: int Read(int first = 3, int last = 7)
Into: int Read(int first = 5, int last = 7)
*/
using System;
class Program
{
    static int checks, failures;
    static int Read(int first = 3, int last = 7) { return first * 10 + last; }
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Check(Read() == 37, "both-optional-arguments");
        Check(Read(last: 9) == 39, "omitted-first-argument");
        Check(Read(first: 5) == 57, "omitted-last-argument");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
