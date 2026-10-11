/*
Rules: E16-4-5-value-field-default; E16-4-5-reference-field-default; E16-4-5-reference-default; E16-4-5-default-constructor-equivalence; E16-4-5-implicit-default-constructor
Authority: ECMA-334 7th ed 16.4.5
Version: 7.3
Expected: run
Stdout: OK 5
Mutate: Entry created = new Entry();
Into: Entry created = new Entry(1);
*/
using System;
struct Entry
{
    public int Number;
    public bool Flag;
    public object Reference;
    public Entry(int value) { Number = value; Flag = true; Reference = new object(); }
}
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Entry value = default(Entry);
        Entry created = new Entry();
        object reference = default(object);
        Check(value.Number == 0 && !value.Flag, "value-field-defaults");
        Check(value.Reference == null, "reference-field-default");
        Check(reference == null, "reference-type-default");
        Check(created.Number == value.Number && created.Flag == value.Flag, "default-constructor-value-fields");
        Check(created.Reference == value.Reference, "default-constructor-reference-field");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
