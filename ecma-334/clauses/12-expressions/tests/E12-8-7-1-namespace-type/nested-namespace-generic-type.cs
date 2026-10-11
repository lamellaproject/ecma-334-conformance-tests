/*
Rules: E12-8-7-1-namespace-type; E12-8-7-1-nested-namespace
Authority: ECMA-334 7th ed 12.8.7.1
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: Source.Branch.Worker<int>.Value
Into: Source.Branch.Worker.Value
*/
using System;
namespace Source.Branch
{
    public class Worker { public static int Value = 8; }
    public class Worker<T> { public static int Value = 3; }
}
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        int result = Source.Branch.Worker<int>.Value;
        Check(result == 3, "namespace-access-constructs-type-with-matching-arity");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
