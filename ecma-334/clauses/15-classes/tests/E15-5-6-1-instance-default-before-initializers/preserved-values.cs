/*
Rules: E15-5-6-1-instance-default-before-initializers
Authority: ECMA-334 7th ed 15.5.6.1
Version: 7.3
Expected: run
Stdout: OK 6
Mutate: public int Number = 19;
Into: public int Number;
*/
using System;
class Holder
{
    public int Number = 19;
    public object Owner = new object();
    public bool Ready = true;
    public int BodyNumber;
    public object BodyOwner;
    public bool BodyReady;
    public Holder() { BodyNumber = Number; BodyOwner = Owner; BodyReady = Ready; }
}
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Holder value = new Holder();
        // Default initialization must precede the assignments, preserving their nondefault values.
        Check(value.Number == 19, "default-initialization-does-not-erase-number-initializer");
        Check(value.Owner != null, "default-initialization-does-not-erase-reference-initializer");
        Check(value.Ready, "default-initialization-does-not-erase-bool-initializer");
        Check(value.BodyNumber == 19, "constructor-observes-initialized-number");
        Check(value.BodyOwner == value.Owner, "constructor-observes-initialized-reference");
        Check(value.BodyReady, "constructor-observes-initialized-bool");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
