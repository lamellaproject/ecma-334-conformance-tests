/*
Rules: E12-8-4-alias-match
Authority: ECMA-334 7th ed 12.8.4
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: using Chosen = Source.Cell;
Into: using Chosen = Source.Other;
*/
using System;
using Chosen = Source.Cell;
namespace Source
{
    public class Cell { public static int Value = 3; }
    public class Other { public static int Value = 8; }
}
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        int result = Chosen.Value;
        Check(result == 3, "simple-name-resolves-using-type-alias");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
