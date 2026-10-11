/*
Rules: E12-10-5-string-concatenation; E12-10-5-string-string-predefined; E12-10-5-string-object-predefined; E12-10-5-object-string-predefined; E12-10-5-object-tostring; E12-10-5-character-order
Authority: ECMA-334 7th ed 12.10.5
Version: 7.3
Expected: run
Stdout: OK 5
Mutate: first + last
Into: last + first
*/
using System;
class Text
{
    public override string ToString() { Program.Calls++; return "mn"; }
}
class Program
{
    public static int Calls;
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        string first = "pq", last = "rs"; object text = new Text();
        string r = first + last; Check(r == "pqrs", "string-string-order");
        r = first + text; Check(r == "pqmn", "string-object-order");
        Check(Calls == 1, "virtual-tostring-once");
        r = text + last; Check(r == "mnrs", "object-string-order");
        Check(Calls == 2, "each-concatenation-calls-override");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
