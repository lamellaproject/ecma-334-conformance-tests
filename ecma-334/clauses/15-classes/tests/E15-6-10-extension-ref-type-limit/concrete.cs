/*
Rules: E15-6-10-extension-ref-type-limit
Authority: ECMA-334 7th ed 15.6.10
Version: 7.3
Expected: run
Stdout: OK 2
Mutate: struct Parcel
Into: class Parcel
*/
using System;
struct Parcel { public int Value; }
static class Extensions
{
    public static void Add(this ref Parcel receiver, int amount) { receiver.Value += amount; }
}
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Parcel value = new Parcel();
        value.Value = 13;
        value.Add(16);
        Check(value.Value == 29, "concrete-value-type-ref-extension-updates-original-receiver");
        Extensions.Add(ref value, 18);
        Check(value.Value == 47, "ref-extension-is-also-callable-with-an-explicit-first-reference-argument");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
