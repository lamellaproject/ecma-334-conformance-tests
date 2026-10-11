/*
Rules: E22-3-form-mixed-arguments; E22-3-form-positional-arguments; E22-3-form-named-arguments; E22-3-form-positional-list; E22-3-form-positional-argument; E22-3-form-named-list; E22-3-form-named-argument; E22-3-form-argument-expression; E22-3-specification-definition
Authority: ECMA-334 7th ed 22.3
Version: 7.3
Expected: run
Stdout: OK 4
Mutate: [Mark(second: 9, first: 7, Field = 4, Other = 5)]
Into: [Mark(second: 10, first: 7, Field = 4, Other = 5)]
*/
using System;
class MarkAttribute : Attribute
{
    public int First, Second, Field, Other;
    public MarkAttribute() { }
    public MarkAttribute(int first, int second) { First = first; Second = second; }
}
[Mark(second: 9, first: 7, Field = 4, Other = 5)] class Mixed { }
[Mark(Field = 6)] class Named { }
[Mark()] class Empty { }
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        var a = (MarkAttribute)Attribute.GetCustomAttribute(typeof(Mixed), typeof(MarkAttribute));
        Check(a.First == 7 && a.Second == 9, "named-constructor-arguments");
        Check(a.Field == 4 && a.Other == 5, "multiple-named-members");
        Check(((MarkAttribute)Attribute.GetCustomAttribute(typeof(Named), typeof(MarkAttribute))).Field == 6, "named-only");
        Check(Attribute.GetCustomAttribute(typeof(Empty), typeof(MarkAttribute)) != null, "empty-parentheses");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
