/*
Rules: E12-8-8-nullable-retain-type; E12-8-8-nullable-retain-null; E12-8-8-nullable-retain-present
Authority: ECMA-334 7th ed 12.8.8
Version: 7.3
Expected: run
Stdout: OK 2
Mutate: filled?.Number
Into: empty?.Number
*/
using System;
struct Cell { public int? Number { get { return 53; } } }
class Program
{
    static int checks, failures;
    static int Kind(int value) { return 1; }
    static int Kind(int? value) { return 2; }
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Cell? filled = new Cell(), empty = null;
        var present = filled?.Number;
        var absent = empty?.Number;
        Check(Kind(present) == 2 && present == 53, "already-nullable-result-retained");
        Check(Kind(absent) == 2 && !absent.HasValue, "absent-receiver-retains-nullable-type");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
