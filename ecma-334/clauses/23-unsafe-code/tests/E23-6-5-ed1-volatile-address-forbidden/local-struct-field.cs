/*
Rules: E23-6-5-ed1-volatile-address-forbidden
Authority: ECMA-334 1st ed 25.5.4
Version: ISO-1
Expected: reject
Version-Witness: tests/E23-6-5-ed1-volatile-address-forbidden/nonvolatile-field.cs.part
Mutate: public volatile int Flag;
Into: public int Flag;
*/
// ECMA-334 1st ed 25.5.4, p. 330 (PDF p. 344), lines 19-20. Refuse taking the address of a
// volatile field even when its containing struct variable is fixed.
public struct FlagCell
{
    public volatile int Flag;
}
class Entry
{
    static unsafe void Main()
    {
        FlagCell value = new FlagCell();
        int* address = &value.Flag;
        if (address == null) throw new System.Exception();
    }
}
