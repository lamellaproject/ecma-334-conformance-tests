/*
Rules: E7-9-finalizer-order-unspecified; E7-9-finalizer-once-normal; E7-9-finalizer-time-unspecified
Authority: ECMA-334 7th ed 7.9
Version: 7.3
Expected: run
Stdout: OK 2
Mutate: new Token(1);
Into: new Token(3);
*/
using System;
using System.Runtime.CompilerServices;
class Token
{
    public static readonly object Gate = new object();
    public static int Count, Order;
    readonly int id;
    public Token(int value) { id = value; }
    ~Token() { lock (Gate) { Order = Order * 10 + id; Count++; } }
}
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    [MethodImpl(MethodImplOptions.NoInlining)]
    static void Release() { new Token(1); new Token(2); }
    static void Main()
    {
        Release();
        // Explicit completion barriers, with no clock deadline or required relative order.
        while (Token.Count < 2) { GC.Collect(); GC.WaitForPendingFinalizers(); }
        Check(Token.Count == 2, "each-eligible-instance-finalized-once");
        Check(Token.Order == 12 || Token.Order == 21, "either-finalizer-order-is-allowed");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
