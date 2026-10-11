/*
Rules: E12-3-1-dynamic-deferred; E12-3-1-dynamic-failure
Authority: ECMA-334 7th ed 12.3.1
Version: 7.3
Expected: run
Stdout: OK 2
Mutate: receiver.Missing()
Into: receiver.Present()
*/
using System;
public class Box { public int Present() { return 7; } }
class Program
{
    static int checks, failures, entered;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static int Invoke(bool active, dynamic receiver)
    {
        if (!active) return 3;
        entered++;
        return receiver.Missing();
    }
    static void Main()
    {
        bool caught = false;
        Check(Invoke(false, new Box()) == 3 && entered == 0, "unexecuted-dynamic-site");
        try { Invoke(true, new Box()); }
        catch (Exception) { caught = true; }
        Check(caught && entered == 1, "binding-exception-at-runtime");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
