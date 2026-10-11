/*
Rules: E22-4-3-runtime-construction
Authority: ECMA-334 7th ed 22.4.3
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: [Explode(true)]
Into: [Explode(false)]
*/
using System;
class ExplodeAttribute : Attribute { public ExplodeAttribute(bool fail) { if (fail) throw new InvalidOperationException(); } }
[Explode(true)] class Item { }
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        int observed = 0;
        try { Attribute.GetCustomAttribute(typeof(Item), typeof(ExplodeAttribute)); }
        catch (InvalidOperationException) { observed = 1; }
        catch (Exception) { observed = 2; }
        Check(observed == 1, "constructor-exception-type");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
