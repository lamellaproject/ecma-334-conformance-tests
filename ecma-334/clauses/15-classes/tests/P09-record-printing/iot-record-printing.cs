/*
Rules: P09-record-printing
Authority: csc 5.11.0-1.26425.128 (C# 9.0)
Version: 9.0
Expected: run
Stdout: OK 2
Mutate: record Banner(string Message) { public static string Omitted = "skip"; }
Into: record Banner(string Message) { public static string Omitted = "skip"; protected virtual bool PrintMembers(System.Text.StringBuilder builder) { builder.Append("wrong"); return true; } }
*/
using System;
record Banner(string Message) { public static string Omitted = "skip"; }
record Empty;
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
        Check(new Banner("north").ToString() == "Banner { Message = north }", "name-value-braces");
        Check(new Empty().ToString() == "Empty { }", "empty-record");
        if (failures == 0) Console.WriteLine("OK " + checks);
        return failures == 0 ? 0 : 1;
    }
}
