/*
Rules: E12-8-7-ed1-inclass-event-field
Authority: ECMA-334 1st ed 14.5.4
Version: ISO-1
Expected: run
Stdout: OK 2
Version-Witness: tests/E12-8-7-ed1-inclass-event-field/virtual-event-field.witness.cs.part
Mutate: this.Signal += callback;
Into: this.Signal -= callback;
*/
// ECMA-334 1st ed 14.5.4, p. 141 (PDF p. 155), lines 5-8 and 34-37. Within its declaring
// type, a field-like event is processed as its static or instance field in every field
// context, including compound assignment.
using System;
delegate void Pulse();
class Source
{
    public virtual event Pulse Signal;
    public bool Attach(Pulse callback)
    {
        this.Signal += callback;
        return this.Signal == callback;
    }
}
class Receiver : Source
{
    public int adds;
    public override event Pulse Signal
    {
        add { adds++; }
        remove { }
    }
}
class Entry
{
    static int checks;
    static int failures;
    static void Check(bool result, string label)
    {
        checks++;
        if (!result)
        {
            failures++;
            Console.WriteLine("FAIL " + label);
        }
    }
    static void Handle() { }
    static int Main()
    {
        Receiver receiver = new Receiver();
        Pulse callback = new Pulse(Handle);
        Check(receiver.Attach(callback), "field-contains-handler");
        Check(receiver.adds == 0, "override-not-called");
        if (failures == 0) Console.WriteLine("OK " + checks);
        return failures == 0 ? 0 : 1;
    }
}
