/*
Rules: E15-5-1-field-member-access
Authority: ECMA-334 7th ed 15.5.1
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: public int Code = 251;
Into: public int Other = 251;
*/
using System;
class Holder { public int Code = 251; }
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Holder value = new Holder();
        Check(value.Code == 251, "member-access-field-read");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
