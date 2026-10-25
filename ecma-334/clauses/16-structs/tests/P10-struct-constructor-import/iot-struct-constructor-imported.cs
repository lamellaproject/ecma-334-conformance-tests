/*
Rules: P10-struct-constructor-import
Authority: csc 5.11.0-1.26425.128 (C# 10.0)
Version: 10.0
Expected: run
Stdout: OK 2
Fixture: {"libraries":[{"name":"Shapes","units":[{"source":"self","defines":["LIBRARY"]}]}],"program":{"references":[{"library":"Shapes"}]}}
Mutate: public Packet() { Calls++; Code = 79; }
Into: public Packet() { Calls++; Code = 0; }
*/
using System;
#if LIBRARY
public readonly record struct Packet
{
    public static int Calls;
    public readonly int Code;
    public Packet() { Calls++; Code = 79; }
}
#else
class Program
{
    static int checks, failures;
    static void Check(bool value, string name)
    {
        checks++;
        if (!value) { failures++; Console.WriteLine("FAIL " + name); }
    }
    static int Main()
    {
        Packet value = new Packet();
        Check(value.Code == 79, "imported-constructor-value");
        Check(Packet.Calls == 1, "imported-constructor-once");
        if (failures == 0) Console.WriteLine("OK " + checks);
        return failures == 0 ? 0 : 1;
    }
}
#endif
