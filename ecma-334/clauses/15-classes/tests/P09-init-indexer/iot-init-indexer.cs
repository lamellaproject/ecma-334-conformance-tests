/*
Rules: P09-init-indexer
Authority: csc 5.11.0-1.26425.128 (C# 9.0)
Version: 9.0
Expected: run
Stdout: OK 3
Mutate: [Take(1)] = Take(47)
Into: [Take(3)] = Take(47)
*/
using System;
class Packet
{
    readonly int[] cells = new int[4];
    public int Calls;
    public int this[int slot] { get { return cells[slot]; } init { Calls++; cells[slot] = value; } }
}
class Program
{
    static int checks, failures, arguments;
    static int Take(int value) { arguments++; return value; }
    static void Check(bool pass, string name)
    {
        checks++;
        if (!pass) { failures++; Console.WriteLine("FAIL " + name); }
    }
    static int Main()
    {
        arguments = 0;
        Packet packet = new Packet { [Take(1)] = Take(47), [Take(2)] = Take(8) };
        Check(packet[1] == 47 && packet[2] == 8, "init-indexer-values");
        Check(packet.Calls == 2 && arguments == 4, "init-indexer-arguments-once");
        Check(packet[0] == 0 && packet[3] == 0, "untouched-indexer-cells");
        if (failures == 0) Console.WriteLine("OK " + checks);
        return failures == 0 ? 0 : 1;
    }
}
