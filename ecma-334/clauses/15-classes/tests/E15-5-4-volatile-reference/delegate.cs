/*
Rules: E15-5-4-volatile-reference
Authority: ECMA-334 7th ed 15.5.4
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: public volatile Reader Value;
Into: public volatile Reader Other;
*/
using System;
delegate int Reader();
class Holder { public volatile Reader Value; }
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static int Read() { return 17; }
    static void Main()
    {
        Holder value = new Holder();
        Reader input = Read;
        value.Value = input;
        Check((object)value.Value == (object)input, "volatile-delegate-reference-identity");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
