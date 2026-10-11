/*
Rules: E12-8-16-7-member-projection-form; E12-8-16-7-projection-name; E12-8-16-7-projection-value
Authority: ECMA-334 7th ed 12.8.16.7
Version: 7.3
Expected: run
Stdout: OK 2
Mutate: new { receiver.Number }
Into: new { Number = other.Number }
*/
using System;
class Receiver
{
    public int Value, Reads;
    public int Number { get { Reads++; return Value; } }
}
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Receiver receiver = new Receiver { Value = 7 }, other = new Receiver { Value = 19 };
        var value = new { receiver.Number };
        receiver.Value = 31;
        Check(value.Number == 7 && receiver.Reads == 1, "member-projection-name-and-snapshot");
        Check(value.Number == 7 && receiver.Reads == 1, "projected-getter-does-not-reread-source");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
