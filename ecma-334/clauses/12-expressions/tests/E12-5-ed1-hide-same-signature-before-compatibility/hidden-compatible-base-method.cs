/*
Rules: E12-5-ed1-hide-same-signature-before-compatibility
Authority: ECMA-334 1st ed 14.3
Version: ISO-1
Expected: reject
Mutate: new Child().Read
Into: ((Parent)new Child()).Read
*/
// ECMA-334 1st ed 14.3, p. 129 (PDF p. 143), lines 27-29 removes the base declaration
// before compatibility.
delegate int Reading();
class Parent
{
    public int Read() { return 39; }
}
class Child : Parent
{
    public new string Read() { return "derived"; }
}
class Entry
{
    public static int Main()
    {
        Reading action = new Reading(new Child().Read);
        return action() == 39 ? 0 : 1;
    }
}
