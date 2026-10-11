/*
Rules: E15-6-2-4-iterator-no-reference
Authority: ECMA-334 7th ed 15.6.2.4
Version: 7.3
Expected: reject
Mutate: ref int value
Into: int value
Csc: CS1623
*/
class Program
{
    static System.Collections.Generic.IEnumerable<int> Numbers(ref int value) { yield return value; }
    static void Main() { }
}
