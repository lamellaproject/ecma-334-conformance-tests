/*
Rules: P11-static-method-most-specific
Authority: csc 5.11.0-1.26425.128 (C# 11.0)
Version: 11.0
Expected: run
Stdout: OK 2
Mutate: static int IDecoder.Decode(int value) { return value + 13; }
Into: static int IDecoder.Decode(int value) { return value - 13; }
*/
using System;
// alpha-v13 interfaces L542/L544: type implementation, then derived interface.
interface IDecoder { static virtual int Decode(int value) { return value * 7; } }
interface IRefined : IDecoder { static int IDecoder.Decode(int value) { return value + 13; } }
struct Parcel : IRefined { }
struct Replacement : IRefined { public static int Decode(int value) { return value * 5; } }
class Program
{
    static int checks, failures;
    static void Check(bool value, string name) { checks++; if (!value) { failures++; Console.WriteLine("FAIL " + name); } }
    static int Decode<T>(int value) where T : IDecoder { return T.Decode(value); }
    static int Main()
    {
        Check(Decode<Parcel>(8) == 21, "derived-interface-priority");
        Check(Decode<Replacement>(8) == 40, "implementing-type-priority");
        if (failures == 0) Console.WriteLine("OK " + checks);
        return failures == 0 ? 0 : 1;
    }
}
