/*
Rules: E12-9-8-1-no-nested-nonasync
Authority: ECMA-334 7th ed 12.9.8.1
Version: 7.3
Expected: reject
Mutate: Action nested = () =>
Into: Action nested = async () =>
*/
using System;
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
    static async void Worker() { Action nested = () => { await new Carrier(); }; }
    static void Main() { }
}
