/*
Rules: E20-4-return-variance
Authority: ECMA-334 7th ed 20.4
Version: 7.3
Expected: run
Stdout: OK 2
Mutate: delegate object ReadObject();
Into: delegate int ReadObject();
*/
using System;
delegate object ReadObject();
delegate string ReadText();
class Program
{
    static int checks, failures;
    static string stored = "beech";
    static string Read() { return stored; }
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        ReadObject method = Read;
        ReadText source = Read;
        ReadObject wrapped = new ReadObject(source);
        object first = method();
        object second = wrapped();
        Check(first == (object)stored, "method-return-reference-conversion");
        Check(second == (object)stored, "delegate-return-reference-conversion");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
