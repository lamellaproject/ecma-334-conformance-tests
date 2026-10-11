/*
Rules: P11-utf8-identity
Authority: csc 5.11.0-1.26425.128 (C# 11.0)
Version: 11.0
Expected: run
Stdout: OK 1
Mutate: ReadOnlySpan<byte> bytes="gneiss"u8;
Into: ReadOnlySpan<byte> bytes=default;
*/
using System;


class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        ReadOnlySpan<byte> bytes="gneiss"u8;Check(bytes.Length==6 && bytes[0]==103 && bytes[5]==115, "P11-utf8-identity-pilot-200001-check-01");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
