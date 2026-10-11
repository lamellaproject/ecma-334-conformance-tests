/*
Rules: E12-21-5-event-add; E12-21-5-event-remove; E12-21-5-event-instance-first; E12-21-5-event-evaluate-right; E12-21-5-event-convert-right; E12-21-5-event-accessor-argument; E12-21-1-event-name
Authority: ECMA-334 7th ed 12.21.5
Version: 7.3
Expected: run
Stdout: OK 4
Mutate: Changed -= Make()
Into: Changed += Make()
*/
using System;
delegate void Handler();
class Converted
{
    public Handler Value;
    public Converted(Handler value) { Value = value; }
    public static implicit operator Handler(Converted value) { Program.trace += "C"; return value.Value; }
}
class Device
{
    public Handler Added, Removed;
    public event Handler Changed
    {
        add { Program.trace += "A"; Added = value; }
        remove { Program.trace += "D"; Removed = value; }
    }
}
class Program
{
    public static string trace = "";
    static Device target = new Device();
    static Handler expected = Handle;
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Handle() { }
    static Device Receiver() { trace += "E"; return target; }
    static Converted Make() { trace += "R"; return new Converted(expected); }
    static void Main()
    {
        Receiver().Changed += Make();
        Check(trace == "ERCA", "event-instance-right-conversion-add-order");
        Check(object.ReferenceEquals(target.Added, expected), "add-receives-converted-sole-argument");
        trace = "";
        Receiver().Changed -= Make();
        Check(trace == "ERCD", "event-remove-accessor-order");
        Check(object.ReferenceEquals(target.Removed, expected), "remove-receives-converted-sole-argument");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
