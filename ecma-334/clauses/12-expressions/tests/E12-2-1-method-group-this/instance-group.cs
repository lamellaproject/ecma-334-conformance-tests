/*
Rules: E12-2-1-method-group-this; E12-2-1-method-group-definition; E12-2-1-method-group-instance; E12-2-1-method-group-type-arguments; E12-2-1-method-group-invocation
Authority: ECMA-334 7th ed 12.2.1
Version: 7.3
Expected: run
Stdout: OK 2
Mutate: Receiver().Choose<int>(5)
Into: other.Choose<int>(5)
*/
using System;
class Box
{
    public int raw;
    public Box(int value) { raw = value; }
    public int Choose<T>(int value) { return this.raw + value; }
    public int Choose<T>(string value) { return -1; }
}
class Program
{
    static int checks, failures, calls;
    static Box chosen = new Box(20), other = new Box(30);
    static Box Receiver() { calls++; return chosen; }
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        int result = Receiver().Choose<int>(5);
        Check(result == 25, "method-group-this-and-overload");
        Check(calls == 1, "group-receiver-once");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
