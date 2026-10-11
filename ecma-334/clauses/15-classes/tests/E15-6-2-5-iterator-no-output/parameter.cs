/*
Rules: E15-6-2-5-iterator-no-output
Authority: ECMA-334 7th ed 15.6.2.5
Version: 7.3
Expected: reject
Mutate: out int value
Into: int value
Csc: CS1623
*/
class Program
{
    static System.Collections.Generic.IEnumerable<int> Numbers(out int value) { value = 67; yield return value; }
    static void Main() { }
}
