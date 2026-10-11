/*
Rules: E12-8-16-6-value-copy-source; E12-8-16-6-value-evaluate
Authority: ECMA-334 7th ed 12.8.16.6
Version: 7.3
Expected: run
Stdout: OK 2
Mutate: new Reader(receiver.Selected)
Into: new Reader(() => receiver.Selected())
*/
using System;
delegate int Reader();
class Receiver
{
    public int Reads;
    public Reader Selected { get { Reads++; return Work; } }
    int Work() { return 23; }
}
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Receiver receiver = new Receiver();
        Reader operation = new Reader(receiver.Selected);
        Check(receiver.Reads == 1, "delegate-valued-property-evaluated-at-creation");
        Check(operation() == 23 && receiver.Reads == 1, "copy-targets-property-value");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
