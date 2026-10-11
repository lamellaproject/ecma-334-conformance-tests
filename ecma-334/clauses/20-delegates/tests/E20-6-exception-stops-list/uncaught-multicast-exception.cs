/*
Rules: E20-6-exception-stops-list; E20-6-multiple-exception-propagation
Authority: ECMA-334 7th ed 20.6
Version: 7.3
Expected: run
Stdout: OK 3
Mutate: static void B() { trace += "B"; throw problem; }
Into: static void B() { trace += "B"; }
*/
using System;
delegate void Notice();
class Problem : Exception { }
class Program
{
    static int checks, failures;
    static string trace = "";
    static Problem problem = new Problem();
    static void A() { trace += "A"; }
    static void B() { trace += "B"; throw problem; }
    static void C() { trace += "C"; }
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Notice notice = (Notice)A + B + C;
        bool caught = false;
        try { notice(); }
        catch (Problem observed) { caught = true; Check(observed == problem, "multicast-exception-instance"); }
        catch (Exception) { Check(false, "wrong-multicast-exception-type"); }
        Check(caught, "multicast-exception-reaches-caller");
        Check(trace == "AB", "remaining-entry-not-invoked");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
