/*
Rules: E15-8-2-field-like-add-thread-safe
Authority: ECMA-334 7th ed 15.8.2
Version: 7.3
Expected: run
Stdout: OK 24
Mutate: Changed += handler;
Into: Changed -= handler;
*/
using System;
using System.Threading;
delegate void Pulse();
struct Source
{
    public event Pulse Changed;
    public void Add(Pulse handler) { Changed += handler; }
    public void Raise()
    {
        Pulse copy = Changed;
        if (copy != null) copy();
    }
}
class Box { public Source State; }
class Gate { public volatile bool Start; public int Ready; }
class Counter { public int Hits; public void Hit() { Hits++; } }
class Worker
{
    public Box Target;
    public Gate Gate;
    public Pulse Handler;
    public Exception Failure;
    public void Run()
    {
        try
        {
            Interlocked.Increment(ref Gate.Ready);
            for (int attempt = 0; attempt < 5000 && !Gate.Start; attempt++) Thread.Sleep(1);
            if (!Gate.Start) throw new InvalidOperationException("worker infrastructure");
            Target.State.Add(Handler);
        }
        catch (Exception problem) { Failure = problem; }
    }
}
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id)
    {
        checks++;
        if (!ok) { failures++; Console.WriteLine("FAIL " + id); }
    }
    static void Main()
    {
        for (int round = 0; round < 24; round++)
        {
            // Every worker updates the same struct variable through its containing field.
            Box box = new Box();
            Gate gate = new Gate();
            Counter[] counters = new Counter[4];
            Worker[] work = new Worker[4];
            Thread[] threads = new Thread[4];
            for (int i = 0; i < work.Length; i++)
            {
                counters[i] = new Counter();
                work[i] = new Worker();
                work[i].Target = box;
                work[i].Gate = gate;
                work[i].Handler = new Pulse(counters[i].Hit);
                threads[i] = new Thread(new ThreadStart(work[i].Run));
                threads[i].IsBackground = true;
            }
            for (int i = 0; i < threads.Length; i++) threads[i].Start();
            bool ready = false;
            for (int attempt = 0; attempt < 5000 && !ready; attempt++)
            {
                ready = Interlocked.CompareExchange(ref gate.Ready, 0, 0) == work.Length;
                if (!ready) Thread.Sleep(1);
            }
            gate.Start = true;
            bool joined = true;
            for (int i = 0; i < threads.Length; i++) joined &= threads[i].Join(5000);
            if (!ready || !joined) throw new InvalidOperationException("worker infrastructure");
            for (int i = 0; i < work.Length; i++)
                if (work[i].Failure != null) throw new InvalidOperationException("worker infrastructure", work[i].Failure);
            box.State.Raise();
            bool ok = true;
            for (int i = 0; i < counters.Length; i++) ok &= counters[i].Hits == 1;
            Check(ok, "internal-struct-add-no-lost-handler");
        }
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
