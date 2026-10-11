/*
Rules: E7-3-class-instance-constructor-declaration; E7-4-5-class-instance-constructor-declaration
Authority: ECMA-334 7th ed 7.3
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: public Holder(int number)
Into: public Renamed(int number)
*/
using System;
class Holder
{
    public int Value;
    public Holder(int number) { Value = number; }
}
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Check(new Holder(41).Value == 41, "instance-constructor-declared");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
