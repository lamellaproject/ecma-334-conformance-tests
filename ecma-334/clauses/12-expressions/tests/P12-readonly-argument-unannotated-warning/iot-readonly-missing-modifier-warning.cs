/*
Rules: P12-readonly-argument-unannotated-warning; P12-readonly-parameter-declaration
Authority: csc 5.11.0-1.26425.128 (C# 12.0)
Version: 12.0
Expected: run
Stdout: OK 2
Diagnostic: warning
Mutate: int observed = Read(value, ref value);
Into: int observed = Read(in value, ref value);
*/
using System;
class Test
{
    static int checks, failures;
    static void Check(bool value, string name)
    {
        checks++;
        if (!value) { failures++; Console.WriteLine("FAIL " + name); }
    }
    static int Read(ref readonly int read, ref int write) { write += 7; return read; }
    static int Main()
    {
        int value = 11;
        int observed = Read(value, ref value);
        Check(observed == 18, "unannotated-variable-keeps-storage-location");
        Check(value == 18, "caller-alias-update");
        if (failures == 0) Console.WriteLine("OK " + checks);
        return failures == 0 ? 0 : 1;
    }
}
