/*
Rules: P08-nullable-doesnotreturn-flow
Authority: csc 5.11.0-1.26425.128 (C# 8.0)
Version: 8.0
Expected: run
Stdout: OK 2
Diagnostic: none
Mutate: [DoesNotReturn] static void Stop()
Into: static void Stop()
*/
#nullable enable
using System;
using System.Diagnostics.CodeAnalysis;
class MissingTextException : Exception { }
class Program
{
    static int checks, failures;
    [DoesNotReturn] static void Stop() { throw new MissingTextException(); }
    static int Size(string? text)
    {
        if (text == null) Stop();
        return text.Length;
    }
    static string? Take() { return "elm"; }
    static void Check(bool pass, string name)
    {
        checks++;
        if (!pass) { failures++; Console.WriteLine("FAIL " + name); }
    }
    static int Main()
    {
        Check(Size(Take()) == 3, "nonnull-path-size");
        bool caught = false;
        try { Size(null); }
        catch (MissingTextException) { caught = true; }
        Check(caught, "null-path-terminates");
        if (failures == 0) Console.WriteLine("OK " + checks);
        return failures == 0 ? 0 : 1;
    }
}
