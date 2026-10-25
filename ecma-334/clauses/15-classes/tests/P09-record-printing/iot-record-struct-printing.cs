/*
Rules: P09-record-printing
Authority: csc 5.11.0-1.26425.128 (C# 10.0)
Version: 10.0
Expected: run
Stdout: OK 3
Mutate: readonly record struct Label {
Into: readonly record struct Label { public override string ToString() { return "Label"; }
*/
using System;
readonly record struct Label {
    public readonly string Name;
    public string Hint { get { return "leaf"; } }
    public static string Ignored { get { return "static"; } }
    public Label(string name) { Name = name; }
}
readonly record struct Blank;
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
        string text = new Label("willow").ToString();
        Check(text == "Label { Name = willow, Hint = leaf }", "public-member-rendering");
        Check(text.IndexOf("Ignored") < 0, "static-property-excluded");
        Check(new Blank().ToString() == "Blank { }", "empty-rendering");
        if (failures == 0) Console.WriteLine("OK " + checks);
        return failures == 0 ? 0 : 1;
    }
}
