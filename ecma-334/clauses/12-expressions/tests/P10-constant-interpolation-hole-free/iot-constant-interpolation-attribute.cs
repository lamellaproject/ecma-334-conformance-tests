/*
Rules: P10-constant-interpolation-hole-free; E22-3-argument-compile-time-value
Authority: csc 5.11.0-1.26425.128 (C# 10.0)
Version: 10.0
Expected: run
Stdout: OK 2
Mutate: [Label($"harbor")]
Into: [Label($"shoal")]
*/
using System;

class LabelAttribute : Attribute
{
    public readonly string Text;
    public LabelAttribute(string text) { Text = text; }
}
[Label($"harbor")]
class Marked { }
class Program
{
    static int checks, failures;
    static void Check(bool value, string name)
    {
        checks++;
        if (!value) { failures++; Console.WriteLine("FAIL " + name); }
    }
    static int Main()
    {
        // Reflection observes the constant emitted in the attribute metadata.
        object[] attributes = typeof(Marked).GetCustomAttributes(typeof(LabelAttribute), false);
        Check(attributes.Length == 1, "one-attribute");
        Check(attributes.Length == 1 && ((LabelAttribute)attributes[0]).Text == "harbor", "constant-attribute-text");
        if (failures == 0) Console.WriteLine("OK " + checks);
        return failures == 0 ? 0 : 1;
    }
}
