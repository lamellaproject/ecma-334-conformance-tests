/*
Rules: E22-3-auto-property-default
Authority: ECMA-334 7th ed 22.3
Version: 7.3
Expected: run
Stdout: OK 2
Fixture: {"target_requires":["reflection"]}
Mutate: [Note(17)]
Into: [Note(19)]
*/
using System;
[AttributeUsage(AttributeTargets.Property)]
class NoteAttribute : Attribute
{
    public readonly int Value;
    public NoteAttribute(int value) { Value = value; }
}
class Sample
{
    [Note(17)] public int Count { get; set; }
}
class Program
{
    static int checks, failures;
    static void Check(bool good, string name)
    {
        checks++;
        if (!good) { failures++; Console.WriteLine("FAIL " + name); }
    }
    static int Main()
    {
        System.Reflection.PropertyInfo property = typeof(Sample).GetProperty("Count");
        object[] values = property.GetCustomAttributes(typeof(NoteAttribute), false);
        Check(values.Length == 1 && ((NoteAttribute)values[0]).Value == 17, "property-default-target");
        Check(property.GetGetMethod().GetCustomAttributes(typeof(NoteAttribute), false).Length == 0, "getter-has-no-property-attribute");
        if (failures == 0) Console.WriteLine("OK " + checks);
        return failures == 0 ? 0 : 1;
    }
}
