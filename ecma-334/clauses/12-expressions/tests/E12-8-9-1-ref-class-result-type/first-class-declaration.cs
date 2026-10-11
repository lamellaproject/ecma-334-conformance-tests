/*
Rules: E12-8-9-1-ref-class-result-type
Authority: ECMA-334 7th ed 12.8.9.1
Version: 7.3
Expected: run
Stdout: OK 2
Mutate: ref receiver.Slot()
Into: ref ((Base)receiver).Slot()
*/
using System;
class Base { public int first = 3; public ref int Slot() { return ref first; } }
class Derived : Base { public long second = 7; public new ref long Slot() { return ref second; } }
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Derived receiver = new Derived();
        ref long selected = ref receiver.Slot();
        selected = 41;
        Check(receiver.second == 41 && receiver.first == 3, "first-derived-declaration-has-long-location");
        Base baseView = receiver;
        ref int original = ref baseView.Slot();
        original = 43;
        Check(receiver.first == 43 && receiver.second == 41, "base-view-has-int-location");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
