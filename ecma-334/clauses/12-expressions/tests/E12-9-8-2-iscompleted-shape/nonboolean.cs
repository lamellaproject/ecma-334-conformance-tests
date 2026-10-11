/*
Rules: E12-9-8-2-iscompleted-shape
Authority: ECMA-334 7th ed 12.9.8.2
Version: 7.3
Expected: reject
Mutate: public int IsCompleted { get { return 1; } }
Into: public bool IsCompleted { get { return true; } }
*/
using System;
using System.Runtime.CompilerServices;
struct Carrier { public Waiter GetAwaiter() { return new Waiter(); } }
struct Waiter : INotifyCompletion
{
    public int IsCompleted { get { return 1; } }
    public void OnCompleted(Action continuation) { }
    public void GetResult() { }
}
class Program { static async void Worker() { await new Carrier(); } static void Main() { } }
