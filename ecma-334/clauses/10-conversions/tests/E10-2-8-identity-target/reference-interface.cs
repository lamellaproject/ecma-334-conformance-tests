/*
Rules: E10-2-8-identity-target; E10-2-8-identity-preserved
Authority: ECMA-334 7th ed 10.2.8
Version: 7.3
Expected: run
Stdout: OK 2
Mutate: ISlot<dynamic> target = source;
Into: ISlot<dynamic> target = new Holder(new object());
*/
using System;

interface ISlot<T> { T Read(); }
class Holder : ISlot<object>
{
    readonly object value;
    public Holder(object item) { value = item; }
    public object Read() { return value; }
}
class Program
{
    static int checks, failures;
    static void Check(bool ok, string name)
    {
        checks++;
        if (!ok) { failures++; Console.WriteLine("FAIL " + name); }
    }
    static int Main()
    {
        object payload = new object();
        Holder source = new Holder(payload);
        ISlot<dynamic> target = source;
        ISlot<object> erased = target;
        Check(object.ReferenceEquals(target, source), "identity-target/reference");
        Check(object.ReferenceEquals(erased.Read(), payload), "identity-target/payload");
        if (failures == 0) Console.WriteLine("OK " + checks);
        return failures == 0 ? 0 : 1;
    }
}
