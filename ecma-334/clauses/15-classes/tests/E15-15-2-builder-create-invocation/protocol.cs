/*
Rules: E15-15-2-builder-create-invocation; E15-15-2-builder-start-invocation; E15-15-2-builder-start-advances-state-machine; E15-15-2-builder-task-return-after-start; E15-15-2-state-machine-movenext-advance; E15-15-2-builder-success-setresult; E15-15-2-builder-failure-setexception
Authority: ECMA-334 7th ed 15.15.2
Version: 7.3
Expected: run
Stdout: OK 7
Mutate: machine.MoveNext();
Into: ;
*/
using System;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
class Completion
{
    public bool Done;
    public Exception Error;
    public Action Next;
}
[AsyncMethodBuilder(typeof(TokenBuilder))]
class Token
{
    public Completion State;
    public Token(Completion state) { State = state; }
    public Awaiter GetAwaiter() { return new Awaiter(State); }
}
struct Awaiter : INotifyCompletion
{
    Completion state;
    public Awaiter(Completion state) { this.state = state; }
    public bool IsCompleted { get { return state.Done; } }
    public void OnCompleted(Action action) { state.Next = action; }
    public void GetResult() { if (state.Error != null) throw state.Error; }
}
class TokenBuilder
{
    Completion state;
    public static TokenBuilder Create()
    {
        Program.Trace += "C";
        return new TokenBuilder { state = new Completion() };
    }
    public Token Task { get { Program.Trace += "T"; return new Token(state); } }
    public void Start<S>(ref S machine) where S : IAsyncStateMachine
    {
        Program.Trace += "S";
        machine.MoveNext();
        Program.Trace += "E";
    }
    public void SetStateMachine(IAsyncStateMachine machine) { }
    public void SetException(Exception error) { Program.Trace += "F"; state.Error = error; state.Done = true; }
    public void SetResult() { Program.Trace += "R"; state.Done = true; }
    public void AwaitOnCompleted<A, S>(ref A awaiter, ref S machine)
        where A : INotifyCompletion where S : IAsyncStateMachine { awaiter.OnCompleted(machine.MoveNext); }
    public void AwaitUnsafeOnCompleted<A, S>(ref A awaiter, ref S machine)
        where A : ICriticalNotifyCompletion where S : IAsyncStateMachine { awaiter.UnsafeOnCompleted(machine.MoveNext); }
}
class Fault : Exception { }
class Program
{
    static int checks, failures;
    public static string Trace = "";
    static Fault Failure = new Fault();
    static async Token Work(bool fail)
    {
        Trace += "B";
        await System.Threading.Tasks.Task.FromResult(0);
        Trace += "A";
        if (fail) throw Failure;
    }
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Token success = Work(false);
        Check(Trace == "CSBARET", "create-start-body-setresult-start-return-task-order");
        Check(success != null && success.State.Done, "setresult-completes-returned-builder-task");
        Check(success.State.Error == null, "successful-state-machine-does-not-call-setexception");
        Trace = "";
        Token failure = Work(true);
        Check(Trace == "CSBAFET", "state-machine-exception-calls-setexception-before-task-return");
        Check(failure.State != success.State, "each-create-produces-own-builder-and-return-task-state");
        Check(failure.State.Done && failure.State.Error == Failure, "setexception-receives-uncaught-exception-identity");
        Fault caught = null;
        try { failure.GetAwaiter().GetResult(); } catch (Fault ex) { caught = ex; } catch (Exception) { }
        Check(caught == Failure, "builder-task-observes-same-exception");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
