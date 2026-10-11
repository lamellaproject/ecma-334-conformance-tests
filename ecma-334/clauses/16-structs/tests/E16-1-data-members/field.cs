/*
Rules: E16-1-data-members; E16-2-6-body-members; E16-3-declared-members; E16-3-member-field
Authority: ECMA-334 7th ed 16.1
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: public int Payload;
Into: 
*/
using System;
struct Record { public int Payload; }
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Record item = new Record(); item.Payload = 43;
        Check(item.Payload == 43, "declared-field");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
