/*
Rules: E7-7-1-expanded-construct-variable-scope
Authority: ECMA-334 7th ed 7.7.1
Version: 7.3
Expected: run
Stdout: OK 2
Mutate: using (Slot value = new Slot())
Into: using (Slot renamed = new Slot())
*/
using System;
class Slot : IDisposable
{
    public int Value = 229;
    public static int Disposed;
    public void Dispose() { Disposed++; }
}
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        using (Slot value = new Slot()) { Check(value.Value == 229, "resource-visible-in-expanded-using-body"); }
        Check(Slot.Disposed == 1, "using-expansion-disposes-resource");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
