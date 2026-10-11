/*
Rules: E12-12-7-applicable-operator-precedence
Authority: ECMA-334 7th ed 12.12.7
Version: 7.3
Expected: run
Stdout: OK 4
Mutate: first == same
Into: (object)first == same
*/
using System;
class Item
{
    public static bool operator ==(Item x, Item y) { Program.Calls++; return (object)x != (object)y; }
    public static bool operator !=(Item x, Item y) { Program.Calls++; return (object)x == (object)y; }
    public override bool Equals(object x) { return (object)this == x; }
    public override int GetHashCode() { return 0; }
}
class Program
{
    public static int Calls;
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Item first = new Item(), same = first, other = new Item();
        Check(!(first == same), "custom-equality-before-identity");
        Check(first != same, "custom-inequality-before-identity");
        Check(first == other && !(first != other), "custom-results-for-different-references");
        Check(Calls == 4, "operators-called");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
