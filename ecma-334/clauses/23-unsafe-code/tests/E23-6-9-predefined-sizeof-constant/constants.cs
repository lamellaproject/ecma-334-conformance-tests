/*
Rules: E23-6-9-predefined-sizeof-constant
Authority: ECMA-334 7th ed 23.6.9
Version: 7.3
Expected: run
Stdout: OK 13
Mutate: const int intSize = sizeof(int);
Into: const int intSize = sizeof(short);
*/
using System;
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        // The predefined set and sizes are the table in 12.8.18, printed page 221 (PDF page 249).
        const int signed8 = sizeof(sbyte), unsigned8 = sizeof(byte);
        const int signed16 = sizeof(short), unsigned16 = sizeof(ushort);
        const int intSize = sizeof(int);
        const int unsigned32 = sizeof(uint), signed64 = sizeof(long), unsigned64 = sizeof(ulong);
        const int character = sizeof(char), single = sizeof(float), twice = sizeof(double);
        const int logical = sizeof(bool), monetary = sizeof(decimal);
        Check(signed8 == 1, "sizeof-sbyte-constant");
        Check(unsigned8 == 1, "sizeof-byte-constant");
        Check(signed16 == 2, "sizeof-short-constant");
        Check(unsigned16 == 2, "sizeof-ushort-constant");
        Check(intSize == 4, "sizeof-int-constant");
        Check(unsigned32 == 4, "sizeof-uint-constant");
        Check(signed64 == 8, "sizeof-long-constant");
        Check(unsigned64 == 8, "sizeof-ulong-constant");
        Check(character == 2, "sizeof-char-constant");
        Check(single == 4, "sizeof-float-constant");
        Check(twice == 8, "sizeof-double-constant");
        Check(logical == 1, "sizeof-bool-constant");
        Check(monetary == 16, "sizeof-decimal-constant");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
