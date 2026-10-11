/*
Rules: E15-6-2-3-iterator-no-input
Authority: ECMA-334 7th ed 15.6.2.3
Version: 7.3
Expected: reject
Mutate: in int value
Into: int value
Csc: CS1623
*/
class Program
{
    static System.Collections.Generic.IEnumerable<int> Numbers(in int value) { yield return value; }
    static void Main() { }
}
