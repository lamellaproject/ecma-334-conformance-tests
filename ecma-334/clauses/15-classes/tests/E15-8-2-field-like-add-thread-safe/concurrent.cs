/*
Rules: E15-8-2-field-like-add-thread-safe
Authority: ECMA-334 7th ed 15.8.2
Version: 7.3
Expected: run
Stdout: OK 24
Mutate: source.Signal += handler;
Into: source.Signal -= handler;
*/
using System;
using System.Threading;
class Source { public event Action Signal; public void Notify() { if (Signal != null) Signal(); } }
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
            int[] counts = new int[4];
            bool[] errors = new bool[4];
            for (int i = 0; i < workers.Length; i++)
            {
                int index = i;
                Action handler = () => counts[index]++;
                workers[i] = new Thread(() =>
                {
                    try { Interlocked.Increment(ref gate.Ready);
                        for (int attempt = 0; attempt < 5000 && !gate.Start; attempt++) Thread.Sleep(1);
                        if (!gate.Start) throw new InvalidOperationException("worker infrastructure"); source.Signal += handler; }
                    catch (Exception) { errors[index] = true; }
                });
                workers[i].IsBackground = true;
                workers[i].Start();
            }
            bool ready = false;
            for (int attempt = 0; attempt < 5000 && !ready; attempt++)
            {
                ready = Volatile.Read(ref gate.Ready) == workers.Length;
                if (!ready) Thread.Sleep(1);
            }
            gate.Start = true;
            bool joined = true;
            for (int i = 0; i < workers.Length; i++) joined &= workers[i].Join(5000);
            if (!ready || !joined) throw new InvalidOperationException("worker infrastructure");
            for (int i = 0; i < errors.Length; i++)
                if (errors[i]) throw new InvalidOperationException("worker infrastructure");
            source.Notify();
            bool ok = true;
            for (int i = 0; i < counts.Length; i++) ok &= counts[i] == 1;
            Check(ok, "concurrent-add-no-lost-handler");
        }
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
