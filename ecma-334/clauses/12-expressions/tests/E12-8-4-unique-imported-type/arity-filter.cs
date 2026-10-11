/*
Rules: E12-8-4-unique-imported-type
Authority: ECMA-334 7th ed 12.8.4
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: Cell<int>.Value
Into: Cell.Value
*/
using System;
using First;
using Second;
namespace First { public class Cell<T> { public static int Value = 3; } }
namespace Second { public class Cell { public static int Value = 8; } }
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        int result = Cell<int>.Value;
        Check(result == 3, "only-one-imported-type-matches-name-and-arity");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
