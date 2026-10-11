/*
Rules: E15-6-1-explicit-interface-name; E15-6-1-grammar-member-name-form-2
Authority: ECMA-334 7th ed 15.6.1
Version: 7.3
Expected: run
Stdout: OK 2
Mutate: int IReader.Read() { return 71; }
Into: int IReader.Read() { return 73; }
*/
using System;
interface IReader { int Read(); }
class Holder : IReader
{
    public int Read() { return 79; }
    int IReader.Read() { return 71; }
}
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Holder value = new Holder();
        IReader reader = value;
        Check(reader.Read() == 71, "qualified-interface-method-implements-interface-slot");
        Check(value.Read() == 79, "ordinary-method-remains-a-separate-member");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
