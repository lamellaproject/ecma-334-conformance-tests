/*
Rules: P11-static-method-explicit-implementation
Authority: csc 5.11.0-1.26425.128 (C# 11.0)
Version: 11.0
Expected: run
Stdout: OK 2
Mutate: static int IDecoder.Decode(int value) { return value + 13; }
Into: static int IDecoder.Decode(int value) { return value - 13; }
*/
using System;
// Proposal L121: explicit static implementation is independent of the public name.
interface IDecoder { static abstract int Decode(int value); }
struct Parcel : IDecoder
{
    static int IDecoder.Decode(int value) { return value + 13; }
    public static int Decode(int value) { return value * 5; }
}
class Program
{
    static int checks, failures;
    static void Check(bool value, string name) { checks++; if (!value) { failures++; Console.WriteLine("FAIL " + name); } }
    static int Decode<T>(int value) where T : IDecoder { return T.Decode(value); }
    static int Main()
    {
        Check(Decode<Parcel>(8) == 21, "qualified-static-slot");
        Check(Parcel.Decode(8) == 40, "ordinary-public-member");
        if (failures == 0) Console.WriteLine("OK " + checks);
        return failures == 0 ? 0 : 1;
    }
}
