/*
Rules: E12-9-8-2-pattern-getawaiter
Authority: ECMA-334 7th ed 12.9.8.2
Version: 7.3
Expected: reject
Mutate: GetAwaiter(int parameter)
Into: GetAwaiter()
*/
using System;
using System.Runtime.CompilerServices;
struct Carrier { public Waiter GetAwaiter(int parameter) { return new Waiter(); } }
struct Waiter : INotifyCompletion
{
    public bool IsCompleted { get { return true; } }
    public void OnCompleted(Action continuation) { }
    public void GetResult() { }
}
class Program { static async void Worker() { await new Carrier(); } static void Main() { } }
