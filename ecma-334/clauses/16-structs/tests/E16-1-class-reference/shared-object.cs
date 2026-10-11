/*
Rules: E16-1-class-reference; E16-4-2-class-reference-semantics; E16-4-2-class-aliasing; E16-4-4-class-assignment
Authority: ECMA-334 7th ed 16.1
Version: 7.3
Expected: run
Stdout: OK 2
Mutate: class Record
Into: struct Record
*/
using System;
class Record { public int Payload; }
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Record first = new Record(); first.Payload = 17;
        Record second = first; second.Payload = 48;
        Check(first.Payload == 48, "aliased-source");
        Check(second.Payload == 48, "aliased-destination");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
