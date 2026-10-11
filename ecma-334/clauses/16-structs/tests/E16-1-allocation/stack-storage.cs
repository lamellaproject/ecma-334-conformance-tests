/*
Rules: E16-1-allocation
Authority: ECMA-334 7th ed 16.1
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: struct Record
Into: class Record
*/
using System;
struct Record { public int Payload; }
unsafe class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Record* storage = stackalloc Record[2];
        storage[1].Payload = 47;
        Check(storage[1].Payload == 47, "struct-stack-storage");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
