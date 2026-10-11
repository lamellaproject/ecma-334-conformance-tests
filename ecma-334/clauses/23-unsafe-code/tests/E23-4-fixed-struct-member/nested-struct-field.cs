/*
Rules: E23-4-fixed-struct-member
Authority: ECMA-334 7th ed 23.4
Version: 7.3
Expected: run
Stdout: OK 2
Mutate: int* p = &local.Data.Value;
Into: int* p = &other.Data.Value;
*/
using System;
struct Inner { public int Value; }
struct Outer { public Inner Data; }
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static unsafe void Main()
    {
        Outer local = new Outer(), other = new Outer();
        local.Data.Value = 37;
        int* p = &local.Data.Value;
        Check(*p == 37, "nested-fixed-field-address");
        *p = 43;
        Check(local.Data.Value == 43, "nested-fixed-field-write");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
