/*
Rules: E12-8-21-inferred-length; E12-8-21-initialized-form; E12-8-21-item-type
Authority: ECMA-334 7th ed 12.8.21
Version: 7.3
Expected: run
Stdout: OK 3
Mutate: stackalloc byte[] { 5, 6, 7 }
Into: stackalloc byte[] { 5, 8, 7 }
*/
using System;
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Span<byte> values = stackalloc byte[] { 5, 6, 7 };
        Check(values.Length == 3, "initializer-count-inferred");
        Check(values[0] == 5 && values[2] == 7, "byte-constant-conversions");
        Check(values[1] == 6, "middle-byte-item");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
