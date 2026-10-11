/*
Rules: E15-15-2-builder-awaitoncompleted-awaiter-constraint
Authority: ECMA-334 7th ed 15.15.2
Version: 7.3
Expected: run
Stdout: OK 6
Mutate: ((INotifyCompletion)(object)awaiter).OnCompleted(((IAsyncStateMachine)(object)machine).MoveNext);
Into: ((INotifyCompletion)(object)awaiter).OnCompleted(delegate { });
*/
using System;
using System.Runtime.CompilerServices;
// 15.15.2, p. 465, read with 7.6, p. 55: constraints are not
// signatures. A weaker constraint accepts every noncritical awaiter the compiler supplies.
class Completion<T>
{
    public bool Done;
    public T Value;
    public Exception Error;
    public Action Next;
    public void Finish(T value) { Value = value; Done = true; if (Next != null) Next(); }
}
[AsyncMethodBuilder(typeof(TokenBuilder<>))]
class Token<T>
{
    Completion<T> state;
    public Token(Completion<T> state) { this.state = state; }
    public Awaiter<T> GetAwaiter() { return new Awaiter<T>(state); }
}
struct Awaiter<T> : INotifyCompletion
{
    Completion<T> state;
    public Awaiter(Completion<T> state) { this.state = state; }
    public bool IsCompleted { get { return state.Done; } }
    public void OnCompleted(Action action) { state.Next = action; }
    public T GetResult() { if (state.Error != null) throw state.Error; return state.Value; }
}
class TokenBuilder<T>
{
    Completion<T> state;
    public static TokenBuilder<T> Create() { Program.Creates++; return new TokenBuilder<T> { state = new Completion<T>() }; }
    public Token<T> Task { get { return new Token<T>(state); } }
    public void Start<TStateMachine>(ref TStateMachine machine) where TStateMachine : IAsyncStateMachine { Program.Starts++; ((IAsyncStateMachine)(object)machine).MoveNext(); }
    public void SetStateMachine(IAsyncStateMachine machine) { }
    public void SetException(Exception error) { state.Error = error; state.Done = true; if (state.Next != null) state.Next(); }
    public void SetResult(T result) { state.Finish(result); }
    public void AwaitOnCompleted<TAwaiter, TStateMachine>(ref TAwaiter awaiter, ref TStateMachine machine) where TStateMachine : IAsyncStateMachine { Program.SafeCalls++; ((INotifyCompletion)(object)awaiter).OnCompleted(((IAsyncStateMachine)(object)machine).MoveNext); }
    public void AwaitUnsafeOnCompleted<TAwaiter, TStateMachine>(ref TAwaiter awaiter, ref TStateMachine machine) where TAwaiter : ICriticalNotifyCompletion where TStateMachine : IAsyncStateMachine { Program.UnsafeCalls++; ((ICriticalNotifyCompletion)(object)awaiter).UnsafeOnCompleted(((IAsyncStateMachine)(object)machine).MoveNext); }
}
class Program
{
    static int checks, failures;
    public static int Creates, Starts, SafeCalls, UnsafeCalls;
    static Completion<int> Input = new Completion<int>();
    static string Trace = "";
    static async Token<int> Work() { Trace += "S"; int value = await new Token<int>(Input); Trace += "E"; return value + 1; }
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Token<int> task = Work();
        Check(Creates == 1 && Starts == 1, "associated-builder-starts-async-method");
        Check(!task.GetAwaiter().IsCompleted && Trace == "S", "async-body-suspends-on-incomplete-awaiter");
        Check(SafeCalls == 1 && UnsafeCalls == 0, "unconstrained-awaiter-is-registered-by-awaitoncompleted");
        Input.Finish(40);
        Check(task.GetAwaiter().IsCompleted, "weaker-awaiter-constraint-allows-task-completion");
        Check(task.GetAwaiter().GetResult() == 41, "async-return-value-is-produced");
        Check(Trace == "SE", "async-body-resumes-once-in-order");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
