/*
Rules: P09-init-readonly-struct
Authority: csc 5.11.0-1.26425.128 (C# 9.0)
Version: 9.0
Expected: run
Stdout: OK 2
Mutate: Code = 47
Into: Code = 48
*/
using System;
readonly struct Packet
{
    public int Code { get; init; }
    public int Tag { get; init; }
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
        Packet packet = new Packet { Code = 47, Tag = 8 };
        Check(packet.Code == 47 && packet.Tag == 8, "readonly-struct-init-values");
        Check(default(Packet).Code == 0, "readonly-struct-default");
        if (failures == 0) Console.WriteLine("OK " + checks);
        return failures == 0 ? 0 : 1;
    }
}
