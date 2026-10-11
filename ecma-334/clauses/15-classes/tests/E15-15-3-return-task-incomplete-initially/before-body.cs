/*
Rules: E15-15-3-return-task-incomplete-initially; E15-15-3-return-task-created; E15-15-3-return-task-name; E15-15-3-async-normal-task-succeeded; E15-15-3-async-termination-leaves-incomplete; E15-15-3-async-body-until-suspension-or-end; E15-15-3-async-return-control-and-task
Authority: ECMA-334 7th ed 15.15.3
Version: 7.3
Expected: run
Stdout: OK 4
Mutate: Completion state = new Completion();
Into: Completion state = new Completion { Done = true };
*/
using System;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
class Completion { public bool Done; public Exception Error; public Action Next; }
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
    Token task;
    public static TokenBuilder Create()
    {
        Completion state = new Completion();
        Token task = new Token(state);
        Program.Created = task;
        return new TokenBuilder { task = task };
    }
    public Token Task { get { return task; } }
    public void Start<S>(ref S machine) where S : IAsyncStateMachine { machine.MoveNext(); }
    public void SetStateMachine(IAsyncStateMachine machine) { }
    public void SetException(Exception error) { task.State.Error = error; task.State.Done = true; }
    public void SetResult() { task.State.Done = true; }
    public void AwaitOnCompleted<A, S>(ref A awaiter, ref S machine)
        where A : INotifyCompletion where S : IAsyncStateMachine { awaiter.OnCompleted(machine.MoveNext); }
    public void AwaitUnsafeOnCompleted<A, S>(ref A awaiter, ref S machine)
        where A : ICriticalNotifyCompletion where S : IAsyncStateMachine { awaiter.UnsafeOnCompleted(machine.MoveNext); }
}
class Program
{
    static int checks, failures;
    public static Token Created;
    static bool BeforeBody;
    static string Trace = "";
    static async Token Work()
    {
        BeforeBody = Created != null && !Created.State.Done && Created.State.Error == null;
        Trace += "B";
        await System.Threading.Tasks.Task.FromResult(0);
        Trace += "E";
    }
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Token task = Work();
        Check(BeforeBody, "return-task-exists-and-is-incomplete-before-body-evaluation");
        Check(task != null && task == Created, "caller-receives-created-return-task-identity");
        Check(Trace == "BE", "unsuspended-body-reaches-end-before-caller-continues");
        Check(task.State.Done && task.State.Error == null, "body-end-transitions-initial-task-to-success");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
