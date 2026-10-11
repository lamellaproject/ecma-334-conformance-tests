/*
Rules: E22-4-3-runtime-named-order
Authority: ECMA-334 7th ed 22.4.3
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: First = 7, Second = 9
Into: Second = 9, First = 7
*/
using System;
class OrderAttribute : Attribute
{
    public static string Trace;
    public OrderAttribute(int value) { Trace = "C" + value; }
    public int First { get { return 0; } set { Trace += "A" + value; } }
    public int Second { get { return 0; } set { Trace += "B" + value; } }
}
[Order(5, First = 7, Second = 9)] class Item { }
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Attribute.GetCustomAttribute(typeof(Item), typeof(OrderAttribute));
        Check(OrderAttribute.Trace == "C5A7B9", "constructor-then-stored-named-order");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
