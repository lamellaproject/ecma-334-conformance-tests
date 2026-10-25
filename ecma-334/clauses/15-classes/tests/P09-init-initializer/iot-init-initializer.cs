/*
Rules: P09-init-initializer
Authority: csc 5.11.0-1.26425.128 (C# 9.0)
Version: 9.0
Expected: run
Stdout: OK 3
Mutate: Code = Take(47)
Into: Code = Take(48)
*/
using System;
class Packet
{
    int code;
    public int Calls;
    public int Code { get { return code; } init { Calls++; code = value; } }
    public int Tag { get; init; }
}
class Program
{
    static int checks, failures, values;
    static int Take(int value) { values++; return value; }
    static void Check(bool pass, string name)
    {
        checks++;
        if (!pass) { failures++; Console.WriteLine("FAIL " + name); }
    }
    static int Main()
    {
        values = 0;
        Packet packet = new Packet { Code = Take(47), Tag = Take(8) };
        Check(packet.Code == 47 && packet.Calls == 1, "manual-init-value-once");
        Check(packet.Tag == 8 && values == 2, "auto-init-value-once");
        Check(new Packet().Tag == 0, "omitted-init-default");
        if (failures == 0) Console.WriteLine("OK " + checks);
        return failures == 0 ? 0 : 1;
    }
}
