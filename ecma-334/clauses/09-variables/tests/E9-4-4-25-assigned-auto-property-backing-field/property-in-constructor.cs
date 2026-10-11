/*
Rules: E9-4-4-25-assigned-auto-property-backing-field
Authority: ECMA-334 7th ed 9.4.4.25
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: Value = value;
Into: ;
*/
using System;
struct Holder
{
    public int Value { get; set; }
    public Holder(int value) { Value = value; }
}
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Holder value = new Holder(49);
        Check(value.Value == 49, "property-assignment-definitely-assigns-hidden-field");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
