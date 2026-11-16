/*
Rules: E8-3-12-nullable-no-interfaces
Authority: ECMA-334 7th ed 8.3.12
Version: 7.3
Expected: run
Stdout: OK 2
Fixture: {"target_requires":["reflection"]}
Mutate: typeof(Payload?)
Into: typeof(Payload)
*/
// ECMA-334 7th ed 8.3.12, p. 82 (PDF p. 110).
using System;
interface ITag { }
struct Payload : ITag { }
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id)
    {
        checks++;
        if (!ok) { failures++; Console.WriteLine("FAIL " + id); }
    }
    static int Main()
    {
        Type[] underlying = typeof(Payload).GetInterfaces();
        Type inspected = typeof(Payload?);
        Type[] nullable = inspected.GetInterfaces();
        Check(underlying.Length == 1 && underlying[0] == typeof(ITag), "underlying-interface");
        Check(nullable.Length == 0, "nullable-interface-set");
        if (failures == 0) Console.WriteLine("OK " + checks);
        return failures == 0 ? 0 : 1;
    }
}
