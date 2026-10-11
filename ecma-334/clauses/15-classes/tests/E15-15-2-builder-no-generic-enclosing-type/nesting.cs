/*
Rules: E15-15-2-builder-no-generic-enclosing-type
Authority: ECMA-334 7th ed 15.15.2
Version: 7.3
Expected: reject
Mutate: #define INVALID
Into: #undef INVALID
*/
#define INVALID
using System;
#if INVALID
using BuilderToken = Outer<int>.TokenBuilder;
#else
using BuilderToken = TokenBuilder;
#endif
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
class Completion { public bool Done; public Exception Error; public Action Next; }
[AsyncMethodBuilder(typeof(BuilderToken))]
class Token
{
    Completion state;
    public Token(Completion state) { this.state = state; }
    public Awaiter GetAwaiter() { return new Awaiter(state); }
}
struct Awaiter : INotifyCompletion
{
    Completion state;
    public Awaiter(Completion state) { this.state = state; }
    public bool IsCompleted { get { return state.Done; } }
    public void OnCompleted(Action action) { state.Next = action; }
    public void GetResult() { if (state.Error != null) throw state.Error; }
}
#if INVALID
class Outer<T>
{
#endif
internal class TokenBuilder
{
    Completion state;
    public static TokenBuilder Create() { Program.Creates++; return new TokenBuilder { state = new Completion() }; }
    public Token Task { get { return new Token(state); } }
    public void Start<TStateMachine>(ref TStateMachine machine) where TStateMachine : IAsyncStateMachine { ((IAsyncStateMachine)(object)machine).MoveNext(); }
    public void SetStateMachine(IAsyncStateMachine machine) { }
    public void SetException(Exception error) { state.Error = error; state.Done = true; if (state.Next != null) state.Next(); }
    public void SetResult() { state.Done = true; if (state.Next != null) state.Next(); }
    public void AwaitOnCompleted<TAwaiter, TStateMachine>(ref TAwaiter awaiter, ref TStateMachine machine) where TAwaiter : INotifyCompletion where TStateMachine : IAsyncStateMachine { ((INotifyCompletion)(object)awaiter).OnCompleted(((IAsyncStateMachine)(object)machine).MoveNext); }
    public void AwaitUnsafeOnCompleted<TAwaiter, TStateMachine>(ref TAwaiter awaiter, ref TStateMachine machine) where TAwaiter : ICriticalNotifyCompletion where TStateMachine : IAsyncStateMachine { ((ICriticalNotifyCompletion)(object)awaiter).UnsafeOnCompleted(((IAsyncStateMachine)(object)machine).MoveNext); }
}
#if INVALID
}
#endif
class Program
{
    static int checks, failures;
    public static int Creates;
    static string Trace = "";
    static async Token Work() { Trace += "S"; await new Token(new Completion { Done = true }); await Task.FromResult(0); Trace += "E"; }
    static async Task Consume(Token task) { await task; }
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Token task = Work();
        Check(task != null && Creates == 1, "class-task-uses-associated-builder");
        Consume(task).GetAwaiter().GetResult();
        Check(Trace == "SE", "class-task-body-executed-once-in-order");
        Check(task.GetAwaiter().IsCompleted, "class-task-can-be-awaited-to-completion");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
