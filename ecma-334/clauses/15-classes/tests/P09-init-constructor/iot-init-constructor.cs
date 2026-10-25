/*
Rules: P09-init-constructor
Authority: csc 5.11.0-1.26425.128 (C# 9.0)
Version: 9.0
Expected: run
Stdout: OK 3
Mutate: base.Code = 47;
Into: base.Code = 48;
*/
using System;
class BasePacket
{
    int code;
    public int Calls;
    public int Code { get { return code; } init { Calls++; code = value; } }
    public BasePacket() { this.Code = 17; }
}
class Packet : BasePacket
{
    public int Tag { get; init; }
    public Packet() { base.Code = 47; this.Tag = 8; }
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
        BasePacket first = new BasePacket();
        Packet second = new Packet();
        Check(first.Code == 17 && first.Calls == 1, "containing-constructor-this");
        Check(second.Code == 47 && second.Calls == 2, "derived-constructor-base");
        Check(second.Tag == 8, "derived-constructor-this");
        if (failures == 0) Console.WriteLine("OK " + checks);
        return failures == 0 ? 0 : 1;
    }
}
