/*
Rules: E15-8-2-field-like-remove-thread-safe
Authority: ECMA-334 7th ed 15.8.2
Version: 7.3
Expected: run
Stdout: OK 24
Mutate: source.Signal -= handler;
Into: source.Signal += handler;
*/
using System;
using System.Threading;
class Source { public event Action Signal; public bool Empty() { return Signal == null; } }
class Gate { public volatile bool Start; public int Ready; }
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        for (int round = 0; round < 24; round++)
        {
            Source source = new Source();
            Gate gate = new Gate();
            Thread[] workers = new Thread[4];
            bool[] errors = new bool[4];
            for (int i = 0; i < workers.Length; i++)
            {
                int index = i;
                Action handler = () => { errors[index] = true; };
                source.Signal += handler;
                workers[i] = new Thread(() =>
                {
                    try { Interlocked.Increment(ref gate.Ready); while (!gate.Start) Thread.Yield(); source.Signal -= handler; }
                    catch (Exception) { errors[index] = true; }
                });
                workers[i].IsBackground = true;
                workers[i].Start();
            }
            while (Volatile.Read(ref gate.Ready) != workers.Length) Thread.Yield();
            gate.Start = true;
            bool ok = true;
            for (int i = 0; i < workers.Length; i++) ok &= workers[i].Join(5000) && !errors[i];
            Check(ok && source.Empty(), "concurrent-remove-no-retained-handler");
        }
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
