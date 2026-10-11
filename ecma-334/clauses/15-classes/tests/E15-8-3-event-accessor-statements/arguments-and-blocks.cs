/*
Rules: E15-8-3-event-accessor-statements; E15-8-3-event-add-block-execution; E15-8-3-event-remove-block-execution; E15-8-3-event-add-method-form; E15-8-3-event-remove-method-form; E15-8-3-event-accessor-value-parameter; E15-8-3-event-plus-uses-add; E15-8-3-event-minus-uses-remove; E15-8-3-event-assignment-argument
Authority: ECMA-334 7th ed 15.8.3
Version: 7.3
Expected: run
Stdout: OK 4
Mutate: Added = value;
Into: Added = null;
*/
using System;
class Source
{
    public Action Added, Removed;
    public int Trace;
    public event Action Signal
    {
        add { if (value == null) return; Trace = Trace * 10 + 3; Added = value; value = null; }
        remove { if (value == null) return; Trace = Trace * 10 + 7; Removed = value; value = null; }
    }
}
class Program
{
    static int checks, failures, evaluations;
    static Action argument;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static Action Operand() { evaluations++; return argument; }
    static void Main()
    {
        Source source = new Source();
        argument = () => { };
        source.Signal += Operand();
        Check(source.Trace == 3 && source.Added == argument && source.Removed == null, "plus-add-block-and-value");
        Check(evaluations == 1 && argument != null, "add-argument-once-by-value");
        source.Signal -= Operand();
        Check(source.Trace == 37 && source.Removed == argument, "minus-remove-block-and-value");
        Check(evaluations == 2 && argument != null, "remove-argument-once-by-value");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
