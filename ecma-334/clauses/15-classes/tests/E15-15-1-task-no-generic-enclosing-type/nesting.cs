/*
Rules: E15-15-1-task-no-generic-enclosing-type
Authority: ECMA-334 7th ed 15.15.1
Version: 7.3
Expected: reject
Version-Witness: version-witnesses/nesting-914a5baddf.cs.part
Mutate: #define INVALID
Into: #undef INVALID
*/
#define INVALID
using System;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
#if INVALID
using TaskToken = Outer<int>.Token;
#else
using TaskToken = Token;
#endif
class Completion { public Exception Error; public bool Done; public Action Next; }
#if INVALID
class Outer<T>
{
#endif
    [AsyncMethodBuilder(typeof(TokenBuilder))]
    internal class Token
    {
        Completion state;
        public Token(Completion state) { this.state = state; }
        public Awaiter GetAwaiter() { return new Awaiter(state); }
    }
#if INVALID
}
#endif
struct Awaiter : INotifyCompletion
{
    Completion state;
    public Awaiter(Completion state) { this.state = state; }
    public bool IsCompleted { get { return state.Done; } }
    public void OnCompleted(Action next) { state.Next = next; }
    public void GetResult() { if (state.Error != null) throw state.Error; }
}
class TokenBuilder
{
    Completion state;
    public static TokenBuilder Create() { return new TokenBuilder { state = new Completion() }; }
    public TaskToken Task { get { return new TaskToken(state); } }
    public void Start<S>(ref S machine) where S : IAsyncStateMachine { machine.MoveNext(); }
    public void SetStateMachine(IAsyncStateMachine machine) { }
    public void SetException(Exception error) { state.Error = error; state.Done = true; }
    public void SetResult() { state.Done = true; }
    public void AwaitOnCompleted<A, S>(ref A awaiter, ref S machine)
        where A : INotifyCompletion where S : IAsyncStateMachine { awaiter.OnCompleted(machine.MoveNext); }
    public void AwaitUnsafeOnCompleted<A, S>(ref A awaiter, ref S machine)
        where A : ICriticalNotifyCompletion where S : IAsyncStateMachine { awaiter.UnsafeOnCompleted(machine.MoveNext); }
}
class Program
{
    static async TaskToken Work() { await System.Threading.Tasks.Task.FromResult(0); }
    static void Main() { }
}
