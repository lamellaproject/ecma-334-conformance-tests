/*
Rules: E15-8-5-event-accessor-method-semantics
Authority: ECMA-334 7th ed 15.8.5
Version: 7.3
Expected: run
Stdout: OK 2
Mutate: Source receiver = null;
Into: Source receiver = new Source();
*/
using System;
class Source { public virtual event Action Signal { add { } remove { } } }
class Program
{
    static int checks, failures, evaluations;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static Action Operand() { evaluations++; return () => { }; }
    static void Main()
    {
        Source receiver = null;
        bool addNull = false, removeNull = false;
        try { receiver.Signal += Operand(); }
        catch (NullReferenceException) { addNull = true; }
        catch (Exception) { }
        Check(addNull && evaluations == 1, "null-virtual-add-after-argument");
        try { receiver.Signal -= Operand(); }
        catch (NullReferenceException) { removeNull = true; }
        catch (Exception) { }
        Check(removeNull && evaluations == 2, "null-virtual-remove-after-argument");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
