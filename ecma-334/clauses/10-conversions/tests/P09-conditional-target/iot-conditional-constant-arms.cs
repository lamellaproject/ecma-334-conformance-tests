/*
Rules: P09-conditional-target
Authority: csc 5.11.0-1.26425.128 (C# 9.0)
Version: 9.0
Expected: run
Stdout: OK 2
Mutate: choice ? (sbyte)-18 : (byte)47
Into: !choice ? (sbyte)-18 : (byte)47
*/
using System;
class Program
{
    static int checks, failures;
    static short Select(bool choice) { return choice ? (sbyte)-18 : (byte)47; }
    static void Check(bool ok, string name)
    {
        checks++;
        if (!ok) { failures++; Console.WriteLine("FAIL " + name); }
    }
    static int Main()
    {
        Check(Select(true) == -18, "sbyte-true-to-short-target");
        Check(Select(false) == 47, "byte-false-to-short-target");
        if (failures == 0) Console.WriteLine("OK " + checks);
        return failures == 0 ? 0 : 1;
    }
}
