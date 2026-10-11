/*
Rules: E12-6-2-1-property-event-values; E12-6-2-1-event-list
Authority: ECMA-334 7th ed 12.6.2.1
Version: 7.3
Expected: run
Stdout: OK 3
Mutate: box.Value = number;
Into: box.Value = number + 1;
*/
using System;
class Box
{
    public int stored, adds, removes;
    public Action last;
    public int Value { set { stored = value; value = 0; } }
    public event Action Signal
    {
        add { adds++; last = value; value = null; }
        remove { removes++; last = value; value = null; }
    }
}
class Program
{
    static int checks, failures;
    static void Handler() { }
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Box box = new Box(); int number = 17; Action handler = Handler;
        box.Value = number; box.Signal += handler; box.Signal -= handler;
        Check(number == 17 && box.stored == 17, "property-value-parameter-copy");
        Check(handler != null && box.last == handler, "event-value-parameter-copy");
        Check(box.adds == 1 && box.removes == 1, "event-right-operand-arguments");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
