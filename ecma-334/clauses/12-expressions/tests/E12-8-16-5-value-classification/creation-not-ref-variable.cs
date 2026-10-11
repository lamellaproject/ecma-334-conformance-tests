/*
Rules: E12-8-16-5-value-classification
Authority: ECMA-334 7th ed 12.8.16.5
Version: 7.3
Expected: reject
Mutate: Take(ref new int[2])
Into: Take(ref stored)
*/
class Program
{
    static int[] stored;
    static void Take(ref int[] value) { }
    static void Main() { Take(ref new int[2]); }
}
