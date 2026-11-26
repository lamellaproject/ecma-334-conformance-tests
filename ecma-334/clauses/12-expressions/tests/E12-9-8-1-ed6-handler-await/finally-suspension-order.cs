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

    static async Task Unwind(Gate gate, InvalidOperationException problem)
    {
        try
        {
            gate.Mark("throw");
            throw problem;
        }
        finally
        {
            gate.Mark("finally");
            await gate;
            gate.Mark("cleaned");
        }
    }

    static int Main()
    {
        Gate gate = new Gate(8);
        InvalidOperationException problem = new InvalidOperationException();
        Task work = Unwind(gate, problem);
        gate.Mark("caller");
        Check(!work.IsCompleted && gate.HasContinuation, "finally-suspended");
        Check(gate.Resume(), "finally-resumed");
        bool same = false;
        if (work.IsCompleted)
        {
            try { work.GetAwaiter().GetResult(); }
            catch (InvalidOperationException observed)
            {
                same = Object.ReferenceEquals(observed, problem);
                gate.Mark("caught");
            }
        }
        Check(gate.Trace == "throw finally awaiter incomplete register caller result cleaned caught", "finally-order");
        Check(same, "propagated-exception");
        if (failures == 0) Console.WriteLine("OK " + checks);
        return failures == 0 ? 0 : 1;
    }
}
