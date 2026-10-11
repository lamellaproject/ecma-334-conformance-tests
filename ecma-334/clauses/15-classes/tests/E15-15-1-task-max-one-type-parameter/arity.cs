/*
Rules: E15-15-1-task-max-one-type-parameter
Authority: ECMA-334 7th ed 15.15.1
Version: 7.3
Expected: reject
Mutate: #define INVALID
Into: #undef INVALID
*/
#define INVALID
using System;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
class Completion<T> { public T Result; public Exception Error; public bool Done; public Action Next; }
[AsyncMethodBuilder(typeof(TokenBuilder<>))]
#if INVALID
class Token<T, U>
#else
class Token<T>
#endif
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
    public void OnCompleted(Action next) { state.Next = next; }
    public T GetResult() { if (state.Error != null) throw state.Error; return state.Result; }
}
class TokenBuilder<T>
{
    Completion<T> state;
    public static TokenBuilder<T> Create() { return new TokenBuilder<T> { state = new Completion<T>() }; }
#if INVALID
    public Token<T, int> Task { get { return new Token<T, int>(state); } }
#else
    public Token<T> Task { get { return new Token<T>(state); } }
#endif
    public void Start<S>(ref S machine) where S : IAsyncStateMachine { machine.MoveNext(); }
    public void SetStateMachine(IAsyncStateMachine machine) { }
    public void SetException(Exception error) { state.Error = error; state.Done = true; }
    public void SetResult(T result) { state.Result = result; state.Done = true; }
    public void AwaitOnCompleted<A, S>(ref A awaiter, ref S machine)
        where A : INotifyCompletion where S : IAsyncStateMachine { awaiter.OnCompleted(machine.MoveNext); }
    public void AwaitUnsafeOnCompleted<A, S>(ref A awaiter, ref S machine)
        where A : ICriticalNotifyCompletion where S : IAsyncStateMachine { awaiter.UnsafeOnCompleted(machine.MoveNext); }
}
class Program
{
#if INVALID
    static async Token<int, int> Read()
#else
    static async Token<int> Read()
#endif
    { await System.Threading.Tasks.Task.FromResult(0); return 13; }
    static void Main() { }
}
