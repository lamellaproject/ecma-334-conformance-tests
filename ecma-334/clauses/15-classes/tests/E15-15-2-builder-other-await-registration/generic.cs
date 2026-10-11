/*
Rules: E15-15-2-builder-other-await-registration; E15-15-2-builder-safe-callback-advice; E15-15-2-builder-generated-suspension-resumption; E15-15-2-builder-await-getawaiter; E15-15-2-state-machine-movenext-advance; E15-15-2-builder-success-result-argument
Authority: ECMA-334 7th ed 15.15.2
Version: 7.3
Expected: run
Stdout: OK 7
Mutate: public bool IsCompleted { get { return Ready; } }
Into: public bool IsCompleted { get { return true; } }
*/
using System;
using System.Runtime.CompilerServices;
class Completion<T> { public bool Done; public T Result; public Exception Error; public Action Next; }
[AsyncMethodBuilder(typeof(TokenBuilder<>))]
class Token<T>
{
    public Completion<T> State;
    public Token(Completion<T> state) { State = state; }
    public Awaiter<T> GetAwaiter() { return new Awaiter<T>(State); }
}
struct Awaiter<T> : INotifyCompletion
{
    Completion<T> state;
    public Awaiter(Completion<T> state) { this.state = state; }
    public bool IsCompleted { get { return state.Done; } }
    public void OnCompleted(Action action) { state.Next = action; }
    public T GetResult() { if (state.Error != null) throw state.Error; return state.Result; }
}
struct Gate : INotifyCompletion
{
    public static bool Ready;
    public static Action Resume;
    public Gate GetAwaiter() { Program.Trace += "G"; return this; }
    public bool IsCompleted { get { return Ready; } }
    public void OnCompleted(Action action) { Program.Trace += "N"; Resume = action; }
    public void GetResult() { Program.Trace += "Q"; }
}
class TokenBuilder<T>
{
    Completion<T> state;
    public static TokenBuilder<T> Create() { Program.Trace += "C"; return new TokenBuilder<T> { state = new Completion<T>() }; }
    public Token<T> Task { get { Program.Trace += "T"; return new Token<T>(state); } }
    public void Start<S>(ref S machine) where S : IAsyncStateMachine { Program.Trace += "S"; machine.MoveNext(); Program.Trace += "E"; }
    public void SetStateMachine(IAsyncStateMachine machine) { }
    public void SetException(Exception error) { state.Error = error; state.Done = true; }
    public void SetResult(T result) { Program.Trace += "R"; state.Result = result; state.Done = true; }
    public void AwaitOnCompleted<A, S>(ref A awaiter, ref S machine)
        where A : INotifyCompletion where S : IAsyncStateMachine { Program.Trace += "O"; awaiter.OnCompleted(machine.MoveNext); }
    public void AwaitUnsafeOnCompleted<A, S>(ref A awaiter, ref S machine)
        where A : ICriticalNotifyCompletion where S : IAsyncStateMachine { Program.Trace += "K"; awaiter.UnsafeOnCompleted(machine.MoveNext); }
}
class Marker { }
class Program
{
    static int checks, failures;
    public static string Trace = "";
    static async Token<Marker> Read(Marker item) { Trace += "B"; await new Gate(); Trace += "A"; return item; }
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Marker item = new Marker();
        Token<Marker> task = Read(item);
        Check(Trace == "CSBGONET", "noncritical-incomplete-awaiter-selects-safe-builder-registration");
        Check(!task.State.Done && Gate.Resume != null, "safe-registration-saves-action-and-leaves-task-incomplete");
        Gate.Ready = true;
        if (Gate.Resume != null) Gate.Resume();
        Check(Trace == "CSBGONETQAR", "safe-callback-advances-from-await-to-result");
        Check(task.State.Done && task.State.Error == null, "registered-action-completes-state-machine-successfully");
        Check(task.GetAwaiter().GetResult() == item, "generic-setresult-receives-method-return-value-identity");
        Trace = "";
        Token<Marker> completed = Read(item);
        // 15.15.2, p. 466: literal 'Otherwise' appears incorrect; 12.9.8.4, p. 233 skips
        // registration for completed awaiters. This test follows that intent instead.
        Check(Trace == "CSBGQARET", "completed-noncritical-awaiter-skips-both-builder-registration-methods");
        Check(completed.State.Done && completed.State.Result == item, "completed-await-still-records-typed-result");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
