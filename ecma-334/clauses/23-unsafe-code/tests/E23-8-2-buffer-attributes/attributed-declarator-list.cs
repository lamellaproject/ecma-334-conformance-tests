/*
Rules: E23-8-2-buffer-attributes; E23-8-2-attributes-apply-all; E23-8-2-modifiers-apply-all; E23-8-2-form-declarator-list; E23-8-2-form-declarator; E23-8-2-multiple-declaration-equivalence
Authority: ECMA-334 7th ed 23.8.2
Version: 7.3
Expected: run
Stdout: OK 4
Mutate: [Tag(17)]
Into: [Tag(18)]
*/
using System;
[AttributeUsage(AttributeTargets.Field)]
class Tag : Attribute
{
    public int Value;
    public Tag(int value) { Value = value; }
}
unsafe struct Item { [Tag(17)] public fixed short One[2], Two[3]; }
unsafe class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    // Attribute association is the rule under test, so field metadata retrieval is necessary.
    static bool Tagged(string name)
    {
        var field = typeof(Item).GetField(name);
        if (field == null) return false;
        object[] attributes = field.GetCustomAttributes(typeof(Tag), false);
        return attributes.Length == 1 && ((Tag)attributes[0]).Value == 17;
    }
    static void Main()
    {
        Item value = new Item();
        short* first = value.One;
        short* second = value.Two;
        first[0] = 19; first[1] = 23;
        second[0] = 31; second[2] = 37;
        Check(Tagged("One"), "first-buffer-attribute");
        Check(Tagged("Two"), "second-buffer-attribute");
        Check(value.One[0] == 19 && value.One[1] == 23, "first-public-buffer-storage");
        Check(value.Two[0] == 31 && value.Two[2] == 37, "second-public-buffer-storage");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
