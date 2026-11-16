/*
Rules: E15-15-1-ed5-standard-task-return-types
Authority: ECMA-334 5th ed 15.15.1
Version: 5
Expected: reject
Version-Witness: version-witnesses/E15-15-1-ed5-standard-task-return-types/custom-return.cs.part
Mutate: static async Envelope<int> Read()
Into: static async Task<int> Read()
*/
using System;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

[AsyncMethodBuilder(typeof(EnvelopeBuilder<>))]
sealed class Envelope<T>
{
    readonly Task<T> result;
    public Envelope(Task<T> result) { this.result = result; }
    public TaskAwaiter<T> GetAwaiter() { return result.GetAwaiter(); }
}

struct EnvelopeBuilder<T>
{
    AsyncTaskMethodBuilder<T> inner;
    public static EnvelopeBuilder<T> Create()
    {
        EnvelopeBuilder<T> builder = new EnvelopeBuilder<T>();
        builder.inner = AsyncTaskMethodBuilder<T>.Create();
        return builder;
    }
    public Envelope<T> Task { get { return new Envelope<T>(inner.Task); } }
    public void Start<S>(ref S state) where S : IAsyncStateMachine { inner.Start(ref state); }
    public void SetStateMachine(IAsyncStateMachine state) { inner.SetStateMachine(state); }
    public void SetResult(T result) { inner.SetResult(result); }
    public void SetException(Exception error) { inner.SetException(error); }
    public void AwaitOnCompleted<A, S>(ref A awaiter, ref S state)
        where A : INotifyCompletion where S : IAsyncStateMachine
    { inner.AwaitOnCompleted(ref awaiter, ref state); }
    public void AwaitUnsafeOnCompleted<A, S>(ref A awaiter, ref S state)
        where A : ICriticalNotifyCompletion where S : IAsyncStateMachine
    { inner.AwaitUnsafeOnCompleted(ref awaiter, ref state); }
}

class Program
{
    static async Envelope<int> Read() { return await Task.FromResult(29); }
    static void Main() { }
}
