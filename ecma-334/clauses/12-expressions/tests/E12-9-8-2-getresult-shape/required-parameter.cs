/*
Rules: E12-9-8-2-getresult-shape
Authority: ECMA-334 7th ed 12.9.8.2
Version: 7.3
Expected: reject
Mutate: GetResult(int parameter)
Into: GetResult()
*/
using System;
using System.Runtime.CompilerServices;
struct Carrier { public Waiter GetAwaiter() { return new Waiter(); } }
struct Waiter : INotifyCompletion
{
    public bool IsCompleted { get { return true; } }
    public void OnCompleted(Action continuation) { }
    public void GetResult(int parameter) { }
}
class Program { static async void Worker() { await new Carrier(); } static void Main() { } }
