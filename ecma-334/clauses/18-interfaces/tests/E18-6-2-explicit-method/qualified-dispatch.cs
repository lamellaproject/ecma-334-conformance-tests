/*
Rules: E18-6-2-explicit-method; E18-6-2-interface-instance-access; E18-5-qualified-name-form; E18-5-namespace-qualified-name; E18-6-5-explicit-first
Authority: ECMA-334 7th ed 18.6.2
Version: 7.3
Expected: run
Stdout: OK 2
Mutate: int Contract.IRead.Read() { return 157; }
Into: int Contract.IRead.Read() { return Read(); }
*/
using System;
namespace Contract { public interface IRead { int Read(); } }
class Reader : Contract.IRead
{
    int Contract.IRead.Read() { return 157; }
    public int Read() { return 163; }
}
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Reader reader = new Reader();
        Contract.IRead view = reader;
        Check(view.Read() == 157, "explicit-qualified-slot-before-public");
        Check(reader.Read() == 163, "public-member-remains-distinct");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
