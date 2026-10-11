/*
Rules: E20-4-parameter-variance
Authority: ECMA-334 7th ed 20.4
Version: 7.3
Expected: run
Stdout: OK 2
Mutate: delegate int ReadText(string value);
Into: delegate int ReadText(int value);
*/
using System;
delegate int ReadObject(object value);
delegate int ReadText(string value);
class Program
{
    static int checks, failures;
    static object saved;
    static int Read(object value) { saved = value; return 79; }
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        ReadObject source = Read;
        ReadText destination = new ReadText(source);
        Check(destination("larch") == 79, "compatible-source-delegate-parameter");
        Check((string)saved == "larch", "wrapped-delegate-receives-argument");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
