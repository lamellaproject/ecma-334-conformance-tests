/*
Rules: P11-static-method-virtual-default
Authority: csc 5.11.0-1.26425.128 (C# 11.0)
Version: 11.0
Expected: run
Stdout: OK 2
Mutate: static virtual int Decode(int value) { return value + 23; }
Into: static virtual int Decode(int value) { return value - 23; }
*/
using System;
// Proposal L77 and alpha-v13 interfaces L536-L545: default implementation.
interface IDecoder { static virtual int Decode(int value) { return value + 23; } }
struct Plain : IDecoder { }
class Replacement : IDecoder { public static int Decode(int value) { return value * 4; } }
class Program
{
    static int checks, failures;
    static void Check(bool value, string name) { checks++; if (!value) { failures++; Console.WriteLine("FAIL " + name); } }
    static int Decode<T>(int value) where T : IDecoder { return T.Decode(value); }
    static int Main()
    {
        Check(Decode<Plain>(7) == 30, "interface-default");
        Check(Decode<Replacement>(7) == 28, "class-replaces-default");
        if (failures == 0) Console.WriteLine("OK " + checks);
        return failures == 0 ? 0 : 1;
    }
}
