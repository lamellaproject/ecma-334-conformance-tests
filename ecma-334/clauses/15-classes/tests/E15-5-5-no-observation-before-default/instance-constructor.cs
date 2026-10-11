/*
Rules: E15-5-5-no-observation-before-default
Authority: ECMA-334 7th ed 15.5.5
Version: 7.3
Expected: run
Stdout: OK 6
Mutate: public int Number;
Into: public int Number = 31;
*/
using System;
class Holder
{
    public int Number;
    public object Owner;
    public bool Ready;
    public int EarlyNumber;
    public object EarlyOwner;
    public bool EarlyReady;
    public Holder()
    {
        EarlyNumber = Number;
        EarlyOwner = Owner;
        EarlyReady = Ready;
        Number = 17;
        Owner = this;
        Ready = true;
    }
}
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Holder value = new Holder();
        Check(value.EarlyNumber == 0, "first-constructor-number-read-is-default");
        Check(value.EarlyOwner == null, "first-constructor-reference-read-is-default");
        Check(!value.EarlyReady, "first-constructor-bool-read-is-default");
        Check(value.Number == 17, "constructor-number-assignment-follows-default-read");
        Check(value.Owner == value, "constructor-reference-assignment-follows-default-read");
        Check(value.Ready, "constructor-bool-assignment-follows-default-read");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
