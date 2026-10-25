/*
Rules: P12-collection-empty; P12-collection-array; P12-collection-element
Authority: csc 5.11.0-1.26425.128 (C# 12.0)
Version: 12.0
Expected: run
Stdout: OK 4
Mutate: byte[] empty = Receive([]);
Into: byte[] empty = Receive([7]);
*/
using System;
class Program
{
    static int checks, failures;
    static byte[] Receive(byte[] values) { return values; }
    static void Check(bool value, string name)
    {
        checks++;
        if (!value) { failures++; Console.WriteLine("FAIL " + name); }
    }
    static int Main()
    {
        byte[] empty = Receive([]);
        Check(empty != null, "empty-reference-present");
        Check(empty.Length == 0, "empty-argument-length");
        byte value = 113;
        byte[] single = Receive([value]);
        Check(single.Length == 1 && single[0] == value, "singleton-argument");
        byte[] zero = Receive([0]);
        Check(zero.Length == 1 && zero[0] == 0, "zero-element-not-empty");
        if (failures == 0) Console.WriteLine("OK " + checks);
        return failures == 0 ? 0 : 1;
    }
}
