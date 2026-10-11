/*
Rules: E12-8-15-operator-selection; E12-8-15-variable-save; E12-8-15-variable-input-conversion; E12-8-15-variable-operator-call; E12-8-15-variable-output-conversion; E12-8-15-variable-store; E12-8-15-variable-old-result
Authority: ECMA-334 7th ed 12.8.15
Version: 7.3
Expected: run
Stdout: OK 4
Mutate: Leaf before = value++;
Into: Leaf before = ++value;
*/
using System;
class Root
{
    public int Value;
    public Root(int value) { Value = value; }
    public static Leaf operator++(Root value) { Program.seen = value; Program.calls++; return new Leaf(value.Value + 5); }
}
class Leaf : Root { public Leaf(int value) : base(value) { } }
class Program
{
    public static Root seen;
    public static int calls;
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Leaf value = new Leaf(7); Leaf original = value;
        Leaf before = value++;
        Check(object.ReferenceEquals(before, original), "postfix-result-is-saved-old-reference");
        Check(object.ReferenceEquals(seen, original), "inherited-operator-receives-upcast-old-reference");
        Check(value.Value == 12 && !object.ReferenceEquals(value, original), "operator-returned-leaf-stored-in-variable");
        Check(calls == 1, "inherited-operator-called-once");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
