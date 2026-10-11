/*
Rules: E15-3-8-instance-this-receiver; E15-3-8-instance-classification
Authority: ECMA-334 7th ed 15.3.8
Version: 7.3
Expected: run
Stdout: OK 2
Mutate: this.Value = value;
Into: new Packet().Value = value;
*/
using System;
class Packet
{
    public int Value;
    public Packet() { }
    public Packet(int value) { this.Value = value; }
}
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Packet first = new Packet(223);
        Packet second = new Packet(227);
        Check(first.Value == 223, "constructor-this-is-first-receiver");
        Check(second.Value == 227, "constructor-this-is-second-receiver");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
