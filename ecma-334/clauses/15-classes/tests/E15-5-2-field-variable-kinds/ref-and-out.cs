/*
Rules: E15-5-2-field-variable-kinds
Authority: ECMA-334 7th ed 15.5.2
Version: 7.3
Expected: run
Stdout: OK 2
Mutate: public int Own;
Into: public readonly int Own;
*/
using System;
class Holder { public static int Shared; public int Own; }
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Store(out int value) { value = 1009; }
    static void Add(ref int value) { value += 4; }
    static void Main()
    {
        Holder value = new Holder();
        Store(out Holder.Shared);
        Add(ref Holder.Shared);
        Store(out value.Own);
        Add(ref value.Own);
        Check(Holder.Shared == 1013, "static-field-is-variable-for-ref-out");
        Check(value.Own == 1013, "instance-field-is-variable-for-ref-out");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
