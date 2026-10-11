/*
Rules: E9-4-4-16-nested-try-expansion
Authority: ECMA-334 7th ed 9.4.4.16
Version: 7.3
Expected: run
Stdout: OK 2
Mutate: catch (Exception) { cell = 35; }
Into: catch (Exception) { }
*/
using System;
class Program
{
    static int checks, failures, cleaned;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static int Read(bool fail)
    {
        int cell;
        try { if (fail) throw new Exception(); cell = 12; }
        catch (Exception) { cell = 35; }
        finally { cleaned++; }
        return cell;
    }
    static void Main()
    {
        Check(Read(false) == 12 && cleaned == 1, "try-end-through-finally");
        Check(Read(true) == 35 && cleaned == 2, "catch-end-through-finally");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
