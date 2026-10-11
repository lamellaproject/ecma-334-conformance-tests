/*
Rules: E15-6-10-extension-ref-type-limit
Authority: ECMA-334 7th ed 15.6.10
Version: 7.3
Expected: run
Stdout: OK 2
Mutate: where T : struct
Into: // constraint removed
*/
using System;
struct Parcel { public int Value; }
static class Extensions
{
    public static void Clear<T>(this ref T receiver)
        where T : struct
    {
        receiver = default(T);
    }
}
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        int number = 53;
        number.Clear();
        Check(number == 0, "struct-constrained-ref-extension-accepts-a-predefined-value-type");
        Parcel value = new Parcel();
        value.Value = 79;
        value.Clear();
        Check(value.Value == 0, "struct-constrained-ref-extension-accepts-a-declared-struct");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
