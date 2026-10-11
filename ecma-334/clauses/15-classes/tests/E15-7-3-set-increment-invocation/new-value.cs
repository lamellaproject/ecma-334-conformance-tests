/*
Rules: E15-7-3-set-increment-invocation; E15-7-3-set-decrement-invocation
Authority: ECMA-334 7th ed 15.7.3
Version: 7.3
Expected: run
Stdout: OK 4
Mutate: Slot = value;
Into: Slot = value + 1;
*/
using System;
class Box
{
    public int Slot = 12;
    public string Trace = "";
    public int Item { get { Trace += "g"; return Slot; } set { Trace += "s"; Slot = value; } }
}
class Program
{
    static Box box = new Box();
    static Box Receiver() { box.Trace += "r"; return box; }
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        int old = Receiver().Item++;
        Check(old == 12 && box.Slot == 13 && box.Trace == "rgs", "postincrement-set-new-value");
        box.Trace = "";
        int newer = ++Receiver().Item;
        Check(newer == 14 && box.Slot == 14 && box.Trace == "rgs", "preincrement-set-new-value");
        box.Trace = "";
        old = Receiver().Item--;
        Check(old == 14 && box.Slot == 13 && box.Trace == "rgs", "postdecrement-set-new-value");
        box.Trace = "";
        newer = --Receiver().Item;
        Check(newer == 12 && box.Slot == 12 && box.Trace == "rgs", "predecrement-set-new-value");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
