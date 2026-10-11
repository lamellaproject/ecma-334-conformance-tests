/*
Rules: E13-9-5-enumerator-variable-hidden
Authority: ECMA-334 7th ed 13.9.5
Version: 7.3
Expected: reject
Mutate: int copy = e;
Into: int copy = item;
*/
class Program
{
    static void Main()
    {
        foreach (int item in new int[] { 2 }) { int copy = e; }
    }
}
