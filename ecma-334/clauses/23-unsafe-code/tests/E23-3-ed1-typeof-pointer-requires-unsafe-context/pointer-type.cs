/*
Rules: E23-3-ed1-typeof-pointer-requires-unsafe-context
Authority: ECMA-334 1st ed 25.1
Version: ISO-1
Expected: reject
Version-Witness: tests/E23-3-ed1-typeof-pointer-requires-unsafe-context/unsafe-context.cs.part
Mutate: static void Main()
Into: static unsafe void Main()
*/
// ECMA-334 1st ed 25.1, p. 321 (PDF p. 335), line 24. Refuse a typeof expression
// containing a pointer type outside an unsafe context.
class Entry
{
    static void Main()
    {
        System.Type marker = typeof(long*);
        if (marker == null) throw new System.Exception();
    }
}
