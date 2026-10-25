/*
Rules: P09-init-accessor-call
Authority: csc 5.11.0-1.26425.128 (C# 9.0)
Version: 9.0
Expected: run
Stdout: OK 2
Mutate: base.Code = value + 3;
Into: base.Code = value + 4;
*/
using System;
class BasePacket { public int Code { get; init; } }
class Packet : BasePacket
{
    public int Tag { get; init; }
    public int Apply
    {
        init { base.Code = value + 3; this.Tag = value + 8; }
    }
}
class Program
{
    static int checks, failures;
    static void Check(bool pass, string name)
    {
        checks++;
        if (!pass) { failures++; Console.WriteLine("FAIL " + name); }
    }
    static int Main()
    {
        Packet packet = new Packet { Apply = 17 };
        Check(packet.Code == 20, "init-calls-base-init");
        Check(packet.Tag == 25, "init-calls-this-init");
        if (failures == 0) Console.WriteLine("OK " + checks);
        return failures == 0 ? 0 : 1;
    }
}
