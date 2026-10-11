/*
Rules: E9-4-4-33-captured-call-exit
Authority: ECMA-334 7th ed 9.4.4.33
Version: 7.3
Expected: run
Stdout: OK 2
Mutate: else cell = 35;
Into: else { }
*/
using System;
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static int Read(bool choose)
    {
        int cell;
        void Fill() { if (choose) cell = 17; else cell = 35; }
        Fill();
        return cell;
    }
    static void Main()
    {
        Check(Read(true) == 17, "first-local-function-exit-assigned");
        Check(Read(false) == 35, "other-local-function-exit-assigned");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
