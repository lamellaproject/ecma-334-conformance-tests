/*
Rules: E15-5-6-2-static-without-constructor-time
Authority: ECMA-334 7th ed 15.5.6.2
Version: 7.3
Expected: run
Stdout: OK 4
Mutate: public static int Value = Tracker.Initialize();
Into: public static int Value = 23;
*/
using System;
class Tracker
{
    public static int Phase, SeenPhase, Calls;
    public static int Initialize() { Calls++; SeenPhase = Phase; return 23; }
}
class Holder { public static int Value = Tracker.Initialize(); }
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Tracker.Phase = 1;
        new Holder();
        Tracker.Phase = 2;
        int first = Holder.Value;
        // Eager initialization and initialization delayed until this field use are both allowed.
        Check(first == 23, "initializer-completes-before-first-static-field-use");
        Check(Tracker.Calls == 1, "initializer-side-effect-completes-before-first-use");
        Check(0 <= Tracker.SeenPhase && Tracker.SeenPhase <= 2, "any-permitted-earlier-initialization-time");
        Tracker.Phase = 3;
        int second = Holder.Value;
        Check(second == 23 && Tracker.Calls == 1 && Tracker.SeenPhase <= 2, "later-use-does-not-repeat-initialization");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
