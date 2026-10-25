/*
Rules: E13-9-5-ed1-getenumerator-parameterless-signature
Authority: ECMA-334 1st ed 15.8.4
Version: ISO-1
Expected: reject
Mutate: public Iteration GetEnumerator(params int[] padding)
Into: public Iteration GetEnumerator()
*/
// ECMA-334 1st ed 15.8.4, p. 191 (PDF p. 205) requires an exactly parameterless pattern
// signature.
class Collection
{
    public Iteration GetEnumerator(params int[] padding) { return new Iteration(); }
}
class Iteration
{
    public bool MoveNext() { return false; }
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
