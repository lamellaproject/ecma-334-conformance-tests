/*
Rules: E15-5-4-ed1-volatile-native-integer-forbidden
Authority: ECMA-334 1st ed 17.4.3
Version: ISO-1
Expected: reject
Version-Witness: tests/E15-5-4-ed1-volatile-native-integer-forbidden/intptr-repair.cs.part
Mutate: public volatile System.IntPtr Slot
Into: public System.IntPtr Slot
*/
// ECMA-334 1st ed 17.4.3, p. 226 (PDF p. 240), lines 9-13. Refuse a volatile field whose
// type is System.IntPtr or System.UIntPtr, which the old closed volatile type categories
// do not permit.

public class Cell
{
    public volatile System.IntPtr Slot = new System.IntPtr();
}

class ProbeMain
{
    public static int Main()
    {
        return 0;
    }
}
