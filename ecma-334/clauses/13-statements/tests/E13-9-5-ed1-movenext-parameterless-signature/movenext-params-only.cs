/*
Rules: E13-9-5-ed1-movenext-parameterless-signature
Authority: ECMA-334 1st ed 15.8.4
Version: ISO-1
Expected: reject
Mutate: public bool MoveNext(params int[] padding)
Into: public bool MoveNext()
*/
// ECMA-334 1st ed 15.8.4, p. 191 (PDF p. 205) requires an exactly parameterless pattern
// signature.
class Collection
{
    public Iteration GetEnumerator() { return new Iteration(); }
}
class Iteration
{
    public bool MoveNext(params int[] padding) { return false; }
    public int Current { get { return 0; } }
}
class Entry
{
    public static int Main()
    {
        foreach (int item in new Collection()) { if (item < 0) return 1; }
        return 0;
    }
}
