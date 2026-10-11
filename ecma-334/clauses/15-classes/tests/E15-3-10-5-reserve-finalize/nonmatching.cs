/*
Rules: E15-3-10-5-reserve-finalize; E15-3-10-1-reserved-signature-collision
Authority: ECMA-334 7th ed 15.3.10
Version: 7.3
Expected: run
Stdout: OK 0
Mutate: public void Finalize(int unused)
Into: public void Finalize()
*/
using System;
class Receipt
{
    ~Receipt() { }
    public void Finalize(int unused) { }
}
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main() { if (failures == 0) Console.WriteLine("OK " + checks); }
}
