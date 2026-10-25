/*
Rules: E12-8-16-6-ed1-selected-instance-context
Authority: ECMA-334 1st ed 14.5.10.3
Version: ISO-1
Expected: reject
Mutate: public void Send(Leaf value)
Into: public static void Send(Leaf value)
*/
// ECMA-334 1st ed 14.5.10.3, p. 150 (PDF p. 164), lines 4-8 checks the selected method.
// The exact Leaf match is an instance method, so a type receiver is invalid. Repairing
// that modifier preserves the delegate signature and receiver form.
class Root { }
class Leaf : Root { }
delegate void Sink(Leaf value);
class Sender
{
    public void Send(Leaf value) { }
    public static void Send(Root value) { }
}
class Entry
{
    public static int Main()
    {
        Sink operation = new Sink(Sender.Send);
        operation(new Leaf());
        return 0;
    }
}
