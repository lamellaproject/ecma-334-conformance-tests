/*
Rules: P10-struct-constructor-default-bypass; E16-4-5-value-field-default; E16-4-5-reference-field-default
Authority: csc 5.11.0-1.26425.128 (C# 10.0)
Version: 10.0
Expected: run
Stdout: OK 3
Mutate: Stamp a = default(Stamp);
Into: Stamp a = new Stamp();
*/
using System;
readonly record struct Stamp
{
    public static int Calls;
    public readonly int Code;
    public readonly string Text;
    public Stamp() { Calls++; Code = 59; Text = "spruce"; }
}
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
        Stamp a = default(Stamp);
        Stamp b = default;
        Check(a.Code == 0 && a.Text == null, "typed-default-zeroed");
        Check(b.Code == 0 && b.Text == null, "default-literal-zeroed");
        Check(Stamp.Calls == 0, "default-no-body-effects");
        if (failures == 0) Console.WriteLine("OK " + checks);
        return failures == 0 ? 0 : 1;
    }
}
