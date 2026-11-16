/*
Rules: E10-2-1-object-dynamic; E10-2-2-object-dynamic; E10-2-2-generic; E10-2-2-no-effect
Authority: ECMA-334 7th ed 10.2.1
Version: 7.3
Expected: run
Stdout: OK 2
Mutate: object restored = dynamicToken;
Into: object restored = new object();
*/
using System;

class Slot<T>
{
    public T Value;
    public Slot(T value) { Value = value; }
}

class Program
{
    static int checks, failures;
    static object Create() { return new object(); }
    static void Check(bool ok, string id)
    {
        checks++;
        if (!ok) { failures++; Console.WriteLine("FAIL " + id); }
    }
    static void Main()
    {
        object token = Create();
        dynamic dynamicToken = token;
        object restored = dynamicToken;
        Slot<dynamic> first = new Slot<dynamic>(token);
        Slot<object> second = first;
        Check(ReferenceEquals(token, restored), "object-dynamic-identity");
        Check(ReferenceEquals(first, second) && ReferenceEquals(second.Value, token), "generic-identity");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
