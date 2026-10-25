/*
Rules: P10-handler-preference
Authority: csc 5.11.0-1.26425.128 (C# 10.0)
Version: 10.0
Expected: run
Stdout: OK 4
Mutate: Route($"k{word}")
Into: Route($"k{"ab"}")
*/
using System;
using System.Runtime.CompilerServices;
[InterpolatedStringHandler]
struct Capture
{
    public static int Constructions;
    public Capture(int length, int holes) { Constructions++; }
    public void AppendLiteral(string text) { }
    public void AppendFormatted(string value) { }
}
class Program
{
    static int checks, failures;
    static string GetWord() { return "ab"; }
    static char Route(string value) { return 'S'; }
    static char Route(Capture value) { return 'H'; }
    static void Check(bool value, string name) { checks++; if (!value) { failures++; Console.WriteLine("FAIL " + name); } }
    static int Main()
    {
        string word = GetWord();
        Check(Route($"k{word}") == 'H', "nonconstant-prefers-handler");
        Check(Route($"ore") == 'S', "constant-prefers-string");
        Check(Route($"k{"ab"}") == 'S', "constant-hole-prefers-string");
        Check(Capture.Constructions == 1, "only-nonconstant-constructed");
        if (failures == 0) Console.WriteLine("OK " + checks);
        return failures == 0 ? 0 : 1;
    }
}
