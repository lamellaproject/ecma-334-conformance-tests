/*
Rules: E12-6-3-10-lower-unknown-reference
Authority: ECMA-334 7th ed 12.6.3.10
Version: 7.3
Expected: reject
Mutate: new long[] { 2 }
Into: new int[] { 2 }
*/
class Program
{
    static void Common<T>(T[] left, T[] right) { }
    static void Main() { Common(new int[] { 1 }, new long[] { 2 }); }
}
