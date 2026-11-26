/*
Rules: E12-9-8-1-ed6-handler-await
Authority: ECMA-334 6th ed 11.8.8.1
Version: 6
Expected: run
Stdout: OK 4
Fixture: {"program":{"units":[{"source":"self"},{"source":"tests/E12-9-8-1-ed6-handler-await/handler-support.cs.part"}]}}
Mutate: await gate
Into: gate.GetAwaiter().GetResult()
*/
using System;
using System.Threading.Tasks;

class Program
{
    static int checks, failures;

    static void Check(bool condition, string name)
    {
        checks++;
        if (!condition) { failures++; Console.WriteLine("FAIL " + name); }
    }

    static async Task<int> Handle(Gate gate, int input)
    {
        try
        {
            gate.Mark("throw");
            throw new InvalidOperationException();
        }
        catch (InvalidOperationException)
        {
            gate.Mark("catch");
            int increment = await gate;
            gate.Mark("handled");
            return input + increment;
        }
    }

    static int Main()
    {
        Gate gate = new Gate(6);
        Task<int> work = Handle(gate, 17);
        gate.Mark("caller");
        Check(!work.IsCompleted && gate.HasContinuation, "catch-suspended");
        Check(gate.Resume(), "catch-resumed");
        Check(gate.Trace == "throw catch awaiter incomplete register caller result handled", "catch-order");
        Check(work.Status == TaskStatus.RanToCompletion && work.Result == 23, "handled-result");
        if (failures == 0) Console.WriteLine("OK " + checks);
        return failures == 0 ? 0 : 1;
    }
}
