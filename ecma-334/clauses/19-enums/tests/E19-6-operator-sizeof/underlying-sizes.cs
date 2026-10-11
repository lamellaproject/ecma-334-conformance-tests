/*
Rules: E19-6-operator-sizeof
Authority: ECMA-334 7th ed 19.6
Version: 7.3
Expected: run
Stdout: OK 4
Mutate: enum Small : byte
Into: enum Small : int
*/
using System;
enum Small : byte { Mark }
enum Medium : short { Mark }
enum Normal { Mark }
enum Large : ulong { Mark }
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static unsafe void Main()
    {
        const int smallSize = sizeof(Small);
        Check(smallSize == sizeof(byte), "byte-enum-size");
        Check(sizeof(Medium) == sizeof(short), "short-enum-size");
        Check(sizeof(Normal) == sizeof(int), "default-enum-size");
        Check(sizeof(Large) == sizeof(ulong), "ulong-enum-size");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
