/*
Rules: P09-conditional-cast
Authority: csc 5.11.0-1.26425.128 (C# 9.0)
Version: 9.0
Expected: run
Stdout: OK 4
Mutate: (Receipt)(choice ? (byte)11 : (short)29)
Into: choice ? (Receipt)(byte)11 : (Receipt)(short)29
*/
using System;
struct Receipt
{
    public int Value;
    public static implicit operator Receipt(byte value) { Program.trace = Program.trace * 10 + 1; return new Receipt { Value = value }; }
    public static implicit operator Receipt(short value) { Program.trace = Program.trace * 10 + 2; return new Receipt { Value = value }; }
}
class Program
{
    static int checks, failures;
    public static int trace;
    static Receipt Select(bool choice) { return (Receipt)(choice ? (byte)11 : (short)29); }
    static void Check(bool ok, string name)
    {
        checks++;
        if (!ok) { failures++; Console.WriteLine("FAIL " + name); }
    }
    static int Main()
    {
        Receipt a = Select(true);
        Check(a.Value == 11, "cast-true-value");
        Check(trace == 2, "cast-converts-common-short-type");
        trace = 0;
        Receipt b = Select(false);
        Check(b.Value == 29, "cast-false-value");
        Check(trace == 2, "cast-false-one-short-conversion");
        if (failures == 0) Console.WriteLine("OK " + checks);
        return failures == 0 ? 0 : 1;
    }
}
