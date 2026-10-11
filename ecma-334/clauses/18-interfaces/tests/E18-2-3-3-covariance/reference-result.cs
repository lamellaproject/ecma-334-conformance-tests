/*
Rules: E18-2-3-3-covariance; E18-2-3-1-list-form; E18-2-3-1-single-parameter; E18-2-3-1-annotation-out; E18-2-3-1-covariant
Authority: ECMA-334 7th ed 18.2.3.3
Version: 7.3
Expected: run
Stdout: OK 3
Mutate: interface IRead<[Mark] out T>
Into: interface IRead<[Mark] T>
*/
using System;
class MarkAttribute : Attribute { }
interface IRead<[Mark] out T> { T Read(); }
class Reader : IRead<string> { public string Read() { return "elm"; } }
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        IRead<string> source = new Reader();
        IRead<object> destination = source;
        IRead<string> identity = source;
        Check((string)destination.Read() == "elm", "implicit-reference-argument-conversion");
        Check((object)source == (object)destination, "conversion-retains-instance");
        Check(identity == source, "identity-argument-conversion");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
