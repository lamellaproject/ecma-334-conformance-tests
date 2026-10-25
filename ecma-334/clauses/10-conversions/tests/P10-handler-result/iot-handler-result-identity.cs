/*
Rules: P10-handler-result; P10-handler-conversion
Authority: csc 5.11.0-1.26425.128 (C# 10.0)
Version: 10.0
Expected: run
Stdout: OK 4
Mutate: Capture item = $"v{7}";
Into: Capture item = new Capture(1, 1);
*/
using System;
using System.Runtime.CompilerServices;
[InterpolatedStringHandler]
class Capture
{
    public static Capture Constructed;
    public static int Constructions;
    public string Literal = "";
    public int Number;
    public Capture(int length, int holes) { Constructed = this; Constructions++; }
    public void AppendLiteral(string text) { Literal += text; }
    public void AppendFormatted(int value) { Number = value; }
}
class Program
{
    static int checks, failures;
    static void Check(bool value, string name) { checks++; if (!value) { failures++; Console.WriteLine("FAIL " + name); } }
    static int Main()
    {
        // No ToString override: the result is the handler instance itself.
        Capture item = $"v{7}";
        Check(ReferenceEquals(item, Capture.Constructed), "constructed-instance-returned");
        Check(Capture.Constructions == 1, "one-construction");
        Check(item.Literal == "v", "same-instance-literal");
        Check(item.Number == 7, "same-instance-formatted");
        if (failures == 0) Console.WriteLine("OK " + checks);
        return failures == 0 ? 0 : 1;
    }
}
