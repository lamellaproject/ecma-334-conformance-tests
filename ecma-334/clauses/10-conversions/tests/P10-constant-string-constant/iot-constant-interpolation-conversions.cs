/*
Rules: P10-constant-string-constant
Authority: csc 5.11.0-1.26425.128 (C# 10.0)
Version: 10.0
Expected: run
Stdout: OK 3
Mutate: $"bell:{Part}"
Into: $"{Part}:bell"
*/
using System;
class Program
{
    const string Part = "buoy";
    const string Value = $"bell:{Part}";
    static int checks, failures;
    static void Check(bool value, string name)
    {
        checks++;
        if (!value) { failures++; Console.WriteLine("FAIL " + name); }
    }
    static int Main()
    {
        string text = Value;
        object reference = Value;
        Check(text == "bell:buoy", "constant-string-identity-value");
        Check(reference is string && (string)reference == "bell:buoy", "constant-string-reference-value");
        Check(Object.ReferenceEquals(text, reference), "reference-conversion-preserves-identity");
        if (failures == 0) Console.WriteLine("OK " + checks);
        return failures == 0 ? 0 : 1;
    }
}
