/*
Rules: E15-6-10-extension-in-value-type
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
    public static int Read(this in Parcel receiver, int amount) { return receiver.Value + amount; }
}
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Parcel value = new Parcel();
        value.Value = 31;
        Check(value.Read(6) == 37, "concrete-value-type-can-be-an-input-extension-receiver");
        Check(Extensions.Read(in value, 12) == 43, "input-extension-is-also-an-ordinary-static-input-method");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
