/*
Rules: E15-5-6-2-static-before-constructor
Authority: ECMA-334 7th ed 15.5.6.2
Version: 7.3
Expected: run
Stdout: OK 5
Mutate: public static int First = Trace.Mark(3);
Into: public static int First;
*/
using System;
class Trace
{
    public static int Digits;
    public static int Mark(int digit) { Digits = Digits * 10 + digit; return digit; }
}
class Holder
{
    public static int First = Trace.Mark(3);
    public static int Second = Trace.Mark(4);
    public static int AtEntry;
    public static int EntrySum;
    static Holder() { AtEntry = Trace.Digits; EntrySum = First + Second; Trace.Mark(5); }
}
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Check(Holder.First == 3, "first-field-assigned-before-constructor");
        Check(Holder.Second == 4, "second-field-assigned-before-constructor");
        Check(Holder.AtEntry == 34, "all-initializer-side-effects-precede-body-entry");
        Check(Holder.EntrySum == 7, "body-observes-both-field-assignments");
        Check(Trace.Digits == 345, "initializer-sequence-immediately-precedes-constructor-action");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
