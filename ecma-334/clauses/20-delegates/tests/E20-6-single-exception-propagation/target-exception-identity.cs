/*
Rules: E20-6-single-exception-propagation
Authority: ECMA-334 7th ed 20.6
Version: 7.3
Expected: run
Stdout: OK 2
Mutate: static void Raise() { throw problem; }
Into: static void Raise() { }
*/
using System;
delegate void Notice();
class Problem : Exception { }
class Program
{
    static int checks, failures;
    static Problem problem = new Problem();
    static void Raise() { throw problem; }
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Notice notice = Raise;
        bool caught = false;
        try { notice(); }
        catch (Problem observed) { caught = true; Check(observed == problem, "target-exception-instance-preserved"); }
        catch (Exception) { Check(false, "wrong-target-exception-type"); }
        Check(caught, "target-exception-reaches-delegate-caller");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
