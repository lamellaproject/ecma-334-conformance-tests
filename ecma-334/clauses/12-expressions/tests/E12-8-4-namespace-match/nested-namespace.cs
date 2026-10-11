/*
Rules: E12-8-4-namespace-match
Authority: ECMA-334 7th ed 12.8.4
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: Branch.Worker.Value
Into: Fallback.Worker.Value
*/
using System;
namespace World
{
    namespace Branch { public class Worker { public static int Value = 3; } }
    namespace Fallback { public class Worker { public static int Value = 8; } }
    class Program
    {
        static int checks, failures;
        static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
        static void Main()
        {
            int result = Branch.Worker.Value;
            Check(result == 3, "simple-name-resolves-nested-namespace");
            if (failures == 0) Console.WriteLine("OK " + checks);
        }
    }
}
