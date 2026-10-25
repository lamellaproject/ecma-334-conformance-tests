/*
Rules: E15-8-2-ed1-static-event-monitor-required
Authority: ECMA-334 1st ed 17.7.1
Version: ISO-1
Expected: run
Stdout: OK 4
Diagnostic: none
Version-Witness: tests/E15-8-2-ed1-static-event-monitor-required/static-event-monitor-witness.cs.part
Mutate: Emitter.Changed += Handler;
Into: Emitter.Store(Handler);
*/
// ECMA-334 1st ed 17.7.1, p. 251 (PDF p. 265), lines 36-39 requires the designated
// monitor. A worker completing while another thread owns it demonstrates a violation.
// Readiness or join failures are infrastructure failures. A finite blocking interval alone
// does not prove that an implementation used the required monitor. The witness adds a
// caller lock; it does not certify generated accessor code.
using System;
using System.Threading;
delegate void Pulse();
class Emitter
{
    public static event Pulse Changed;
    public static void Store(Pulse value) { Changed = value; }
    public static void Raise()
    {
        Pulse copy = Changed;
        if (copy != null) copy();
    }
}
class Change
{

    public bool Removal;
    public Pulse Handler;
    public object Progress = new object();
    public Exception Failure;
    public void Run()
    {
        // Hold Progress from before the accessor attempt until the worker ends.
        lock (Progress)
        {
            try
            {
                if (Removal) Emitter.Changed -= Handler;
                else Emitter.Changed += Handler;
            }
            catch (Exception problem) { Failure = problem; }
        }
    }
}

class Entry
{
    static int checks;
    static int failures;
    static int hits;
    static void Handler() { hits++; }
    static void Check(bool condition, string name)
    {
        checks++;
        if (!condition) { failures++; Console.WriteLine("FAIL " + name); }
    }
    static bool Observe(bool removal)
    {
        Change change = new Change();

        change.Removal = removal;
        change.Handler = new Pulse(Handler);
        Thread worker = new Thread(new ThreadStart(change.Run));
        worker.IsBackground = true;
        bool ready = false;
        bool finished;
        lock (typeof(Emitter))
        {
            worker.Start();
            for (int attempt = 0; attempt < 5000 && !ready; attempt++)
            {
                if (!Monitor.TryEnter(change.Progress)) ready = true;
                else
                {
                    Monitor.Exit(change.Progress);
                    ready = worker.Join(1);
                }
            }
            finished = ready && worker.Join(500);
        }
        bool joined = worker.Join(5000);
        if (!ready || !joined || change.Failure != null)
            throw new InvalidOperationException("worker infrastructure");
        return !finished;
    }
    public static int Main()
    {

        Check(Observe(false), "add-monitor");
        hits = 0;
        Emitter.Raise();
        Check(hits == 1, "add-state");
        Check(Observe(true), "remove-monitor");
        hits = 0;
        Emitter.Raise();
        Check(hits == 0, "remove-state");
        if (failures == 0) Console.WriteLine("OK " + checks);
        return failures == 0 ? 0 : 1;
    }
}
