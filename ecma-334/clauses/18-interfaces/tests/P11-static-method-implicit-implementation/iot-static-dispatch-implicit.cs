/*
Rules: P11-static-method-implicit-implementation; E18-1-contract
Authority: csc 5.11.0-1.26425.128 (C# 11.0)
Version: 11.0
Expected: run
Stdout: OK 2
Mutate: public static int Decode(int value) { return value + 13; }
Into: public static int Decode(int value) { return value - 13; }
*/
using System;
// Proposal L119: ordinary matching static methods implement the slot.
interface IDecoder { static abstract int Decode(int value); }
struct Parcel : IDecoder
{
    public static int Decode(int value) { return value + 13; }
    public static int Alternate(int value) { return value - 13; }
}
class Envelope : IDecoder
{
    public static int Decode(int value) { return value * 5; }
    public static int Alternate(int value) { return value + 5; }
}
class Program
{
    static int checks, failures;
    static void Check(bool value, string name) { checks++; if (!value) { failures++; Console.WriteLine("FAIL " + name); } }
    static int Decode<T>(int value) where T : IDecoder { return T.Decode(value); }
    static int Main()
    {
        Check(Decode<Parcel>(8) == 21, "struct-implicit");
        Check(Decode<Envelope>(8) == 40, "class-implicit");
        if (failures == 0) Console.WriteLine("OK " + checks);
        return failures == 0 ? 0 : 1;
    }
}
