/*
Rules: P10-constant-interpolation-nonnull-strings
Authority: csc 5.11.0-1.26425.128 (C# 10.0)
Version: 10.0
Expected: run
Stdout: OK 4
Mutate: $"<{Head + "mast"}>"
Into: $"<{"mast" + Head}>"
*/
using System;
class Program
{
    const string Head = "fore";
    const string Blank = "";
    const string Joined = $"<{Head + "mast"}>";
    const string Nested = $"{(true ? $"{Head}:" : "aft")}{nameof(Program)}";
    const string EmptyHole = $"left{Blank}right";
    static string DefaultValue(string value = $"deck:{Head}") { return value; }
    static int checks, failures;
    static void Check(bool value, string name)
    {
        checks++;
        if (!value) { failures++; Console.WriteLine("FAIL " + name); }
    }
    static int Main()
    {
        Check(Joined == "<foremast>", "constant-string-concatenation");
        Check(Nested == "fore:Program", "nested-conditional-nameof");
        Check(EmptyHole == "leftright", "constant-empty-string-hole");
        Check(DefaultValue() == "deck:fore", "constant-parameter-default");
        if (failures == 0) Console.WriteLine("OK " + checks);
        return failures == 0 ? 0 : 1;
    }
}
