/*
Rules: E16-2-2-modifiers-optional; E16-2-2-modifier-internal; E16-2-2-modifier-private; E16-2-2-modifier-protected; E16-2-2-class-modifier-meaning
Authority: ECMA-334 7th ed 16.2.2
Version: 7.3
Expected: run
Stdout: OK 3
Mutate: protected struct Guard
Into: private struct Guard
*/
using System;
class Parent
{
    internal struct Internal { public int Value; }
    private struct Secret { public int Value; }
    protected struct Guard { public int Value; }
    public static int PrivateValue() { Secret item = new Secret(); item.Value = 51; return item.Value; }
}
class Program : Parent
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Parent.Internal inner = new Parent.Internal(); inner.Value = 13;
        Guard guard = new Guard(); guard.Value = 27;
        Check(inner.Value == 13, "internal-same-assembly");
        Check(guard.Value == 27, "protected-derived");
        Check(Parent.PrivateValue() == 51, "private-containing-type");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
