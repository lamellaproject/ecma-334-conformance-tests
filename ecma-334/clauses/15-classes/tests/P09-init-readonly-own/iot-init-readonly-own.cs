/*
Rules: P09-init-readonly-own
Authority: csc 5.11.0-1.26425.128 (C# 9.0)
Version: 9.0
Expected: run
Stdout: OK 2
Mutate: this.code = value;
Into: this.code = value + 1;
*/
using System;
class Packet
{
    readonly int code;
    public int Code { get { return code; } init { this.code = value; } }
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
        Packet packet = new Packet { Code = 47 };
        Check(packet.Code == 47, "init-own-readonly-value");
        Check(new Packet().Code == 0, "unassigned-readonly-default");
        if (failures == 0) Console.WriteLine("OK " + checks);
        return failures == 0 ? 0 : 1;
    }
}
