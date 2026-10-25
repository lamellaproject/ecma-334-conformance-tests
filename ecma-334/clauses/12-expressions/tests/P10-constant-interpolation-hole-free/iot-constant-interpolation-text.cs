/*
Rules: P10-constant-interpolation-hole-free
Authority: csc 5.11.0-1.26425.128 (C# 10.0)
Version: 10.0
Expected: run
Stdout: OK 3
Mutate: const string Regular = $"{{piers}}\n";
Into: const string Regular = $"{{piers}}";
*/
using System;
class Program
{
    const string Regular = $"{{piers}}\n";
    const string Verbatim = $@"dock\piers ""closed""";
    const string Empty = $"";
    static int checks, failures;
    static void Check(bool value, string name)
    {
        checks++;
        if (!value) { failures++; Console.WriteLine("FAIL " + name); }
    }
    static int Main()
    {
        Check(Regular == "{piers}\n", "regular-constant-escapes");
        Check(Verbatim == "dock\\piers \"closed\"", "verbatim-constant-escapes");
        Check(Empty.Length == 0, "empty-constant-text");
        if (failures == 0) Console.WriteLine("OK " + checks);
        return failures == 0 ? 0 : 1;
    }
}
