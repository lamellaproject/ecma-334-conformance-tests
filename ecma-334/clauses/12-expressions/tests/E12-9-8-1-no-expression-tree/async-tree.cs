/*
Rules: E12-9-8-1-no-expression-tree
Authority: ECMA-334 7th ed 12.9.8.1
Version: 7.3
Expected: reject
Mutate: Expression<Action> action
Into: Action action
*/
using System;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;
struct Carrier { public Waiter GetAwaiter() { return new Waiter(); } }
struct Waiter : INotifyCompletion
{
    public bool IsCompleted { get { return true; } }
    public void OnCompleted(Action continuation) { }
    public void GetResult() { }
}
class Program
{
    static void Main() { Expression<Action> action = async () => { await new Carrier(); }; }
}
