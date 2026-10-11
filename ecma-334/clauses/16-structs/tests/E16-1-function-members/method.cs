/*
Rules: E16-1-function-members; E16-3-member-method
Authority: ECMA-334 7th ed 16.1
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: public int Read()
Into: public int Renamed()
*/
using System;
struct Record { public int Read() { return 43; } }
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Record item = new Record();
        Check(item.Read() == 43, "declared-method");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
