/*
Rules: E19-2-named-base-form; E19-2-integral-name-form; E19-2-name-lookup
Authority: ECMA-334 7th ed 19.2
Version: 7.3
Expected: run
Stdout: OK 2
Mutate: using Storage = System.Byte
Into: using Storage = System.Int32
*/
using System;
using Storage = System.Byte;
enum Code : Storage { Signal = 13 }
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Check((byte)Code.Signal == 13, "aliased-base-value");
        Check(unchecked((Code)256) == (Code)0, "alias-resolves-byte-width");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
