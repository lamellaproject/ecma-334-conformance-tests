/*
Rules: E12-8-16-6-value-compatibility; E12-8-16-6-value-copy-source; E12-8-16-6-static-binding
Authority: ECMA-334 7th ed 12.8.16.6
Version: 7.3
Expected: run
Stdout: OK 2
Mutate: new Narrow(source)
Into: new Narrow(value => "different")
*/
using System;
delegate string Broad(object value);
delegate object Narrow(string value);
class Program
{
    static object seen;
    static string Work(object value) { seen = value; return (string)value; }
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Broad source = Work;
        Narrow copy = new Narrow(source);
        string argument = "cedar";
        object result = copy(argument);
        Check(object.ReferenceEquals(seen, argument), "compatible-contravariant-parameter");
        Check(object.ReferenceEquals(result, argument), "compatible-covariant-return");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
