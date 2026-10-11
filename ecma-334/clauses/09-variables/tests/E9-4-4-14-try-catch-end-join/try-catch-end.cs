/*
Rules: E9-4-4-14-try-catch-end-join
Authority: ECMA-334 7th ed 9.4.4.14
Version: 7.3
Expected: run
Stdout: OK 2
Mutate: catch (Exception) { cell = 28; }
Into: catch (Exception) { }
*/
using System;
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static int Read(bool fail)
    {
        int cell;
        try { if (fail) throw new Exception(); cell = 14; }
        catch (Exception) { cell = 28; }
        return cell;
    }
    static void Main()
    {
        Check(Read(false) == 14, "normal-try-end-assigned");
        Check(Read(true) == 28, "catch-end-assigned");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
