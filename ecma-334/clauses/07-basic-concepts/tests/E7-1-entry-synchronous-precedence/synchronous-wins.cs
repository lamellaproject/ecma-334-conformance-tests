/*
Rules: E7-1-entry-synchronous-precedence
Authority: ECMA-334 7th ed 7.1
Version: 7.3
Expected: run
Stdout: OK 0
Mutate: static void Main()
Into: static void Start()
*/
using System;
using System.Threading.Tasks;
class Synchronous
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main() { if (failures == 0) Console.WriteLine("OK " + checks); }
}
class TaskCandidate
{
    static Task Main()
    {
        Console.WriteLine("WRONG task-entry");
        return Task.CompletedTask;
    }
}
