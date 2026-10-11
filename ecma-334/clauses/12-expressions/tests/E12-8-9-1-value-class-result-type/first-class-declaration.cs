/*
Rules: E12-8-9-1-value-class-result-type; E12-8-9-1-value-result-type
Authority: ECMA-334 7th ed 12.8.9.1
Version: 7.3
Expected: run
Stdout: OK 2
Mutate: receiver.Read()
Into: ((Base)receiver).Read()
*/
using System;
class Base { public object Read() { return "base"; } }
class Derived : Base { public new string Read() { return "derived"; } }
class Program
{
    static int checks, failures;
    static int Kind(string value) { return 1; }
    static int Kind(object value) { return 2; }
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Derived receiver = new Derived();
        var value = receiver.Read();
        Check(Kind(value) == 1 && value == "derived", "derived-declaration-result-is-string");
        Base baseView = receiver;
        var other = baseView.Read();
        Check(Kind(other) == 2 && (string)other == "base", "base-declaration-result-is-object");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
