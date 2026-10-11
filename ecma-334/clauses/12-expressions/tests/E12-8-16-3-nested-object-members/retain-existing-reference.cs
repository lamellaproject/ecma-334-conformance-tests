/*
Rules: E12-8-16-3-nested-object-members; E12-8-16-3-nested-value-form
Authority: ECMA-334 7th ed 12.8.16.3
Version: 7.3
Expected: run
Stdout: OK 3
Mutate: Node = { Value = 17 }
Into: Node = new Leaf(17)
*/
using System;
class Leaf { public int Value; public Leaf(int value) { Value = value; } }
class Shell
{
    public Leaf Node;
    public readonly Leaf Remembered;
    public Leaf Property { get; }
    public Shell() { Node = new Leaf(3); Remembered = Node; Property = new Leaf(5); }
}
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Shell value = new Shell { Node = { Value = 17 }, Property = { Value = 19 } };
        Check(object.ReferenceEquals(value.Node, value.Remembered), "nested-object-keeps-original-field-reference");
        Check(value.Node.Value == 17, "nested-object-assigns-existing-field-member");
        Check(value.Property.Value == 19, "nested-object-through-get-only-reference-property");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
