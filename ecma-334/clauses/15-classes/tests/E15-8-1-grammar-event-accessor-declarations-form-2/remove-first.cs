/*
Rules: E15-8-1-grammar-event-accessor-declarations-form-2
Authority: ECMA-334 7th ed 15.8.1
Version: 7.3
Expected: run
Stdout: OK 2
Mutate: remove { Removed += 4; }
Into: remove { Removed += 5; }
*/
using System;
class Source
{
    public int Added, Removed;
    public event Action Signal
    {
        remove { Removed += 4; }
        add { Added += 6; }
    }
}
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Source source = new Source();
        Action handler = () => { };
        source.Signal += handler;
        source.Signal -= handler;
        Check(source.Added == 6, "add-second");
        Check(source.Removed == 4, "remove-first");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
