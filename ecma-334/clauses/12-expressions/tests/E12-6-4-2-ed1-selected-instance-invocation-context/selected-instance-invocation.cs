/*
Rules: E12-6-4-2-ed1-selected-instance-invocation-context
Authority: ECMA-334 1st ed 14.5.5.1
Version: ISO-1
Expected: reject
Mutate: public void Take(Leaf item)
Into: public static void Take(Leaf item)
*/
// ECMA-334 1st ed 14.5.5.1, p. 143 (PDF p. 157), lines 13-17 validates the selected best
// method.
class Root { }
class Leaf : Root { }
class Sender
{
    public void Take(Leaf item) { }
    public static void Take(Root item) { }
}
class Entry
{
    public static int Main()
    {

        Sender.Take(new Leaf());
        return 0;
    }
}
