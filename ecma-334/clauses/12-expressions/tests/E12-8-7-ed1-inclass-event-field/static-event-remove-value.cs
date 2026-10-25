/*
Rules: E12-8-7-ed1-inclass-event-field
Authority: ECMA-334 1st ed 14.5.4
Version: ISO-1
Expected: run
Stdout: OK 2
Version-Witness: tests/E12-8-7-ed1-inclass-event-field/static-event-remove-value.witness.cs.part
Mutate: Pulse result = (Entry.Signal -= callback);
Into: Pulse result = Entry.Signal;
*/
// ECMA-334 1st ed 14.5.4, p. 141 (PDF p. 155), lines 5-8 and 34-37. Within its declaring
// type, a field-like event is processed as its static or instance field in every field
// context, including compound assignment.
using System;
delegate void Pulse();
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
    static event Pulse Signal;
    static void Handle() { }
    static int Main()
    {
        Pulse callback = new Pulse(Handle);
        Entry.Signal = callback;
        Pulse result = (Entry.Signal -= callback);
        Check(result == null, "assignment-value");
        Check(Entry.Signal == null, "field-value");
        if (failures == 0) Console.WriteLine("OK " + checks);
        return failures == 0 ? 0 : 1;
    }
}
