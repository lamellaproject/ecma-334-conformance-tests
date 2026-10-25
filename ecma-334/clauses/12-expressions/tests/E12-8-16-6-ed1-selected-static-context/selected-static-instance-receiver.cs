/*
Rules: E12-8-16-6-ed1-selected-static-context
Authority: ECMA-334 1st ed 14.5.10.3
Version: ISO-1
Expected: reject
Mutate: public static void Send(Leaf value)
Into: public void Send(Leaf value)
*/
// ECMA-334 1st ed 14.5.10.3, p. 150 (PDF p. 164), lines 4-8 checks the selected method.
// The exact Leaf match is static, so an instance receiver is invalid. The other overload
// is not compatible under the 1st edition's 22.1; later filtering may choose it.
class Root { }
class Leaf : Root { }
delegate void Sink(Leaf value);
class Sender
{
    public static void Send(Leaf value) { }
    public void Send(Root value) { }
}
class Entry
{
    public static int Main()
    {
        Sender sender = new Sender();
        Sink operation = new Sink(sender.Send);
        operation(new Leaf());
        return 0;
    }
}
