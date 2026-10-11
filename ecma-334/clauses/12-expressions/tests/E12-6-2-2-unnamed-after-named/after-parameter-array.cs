/*
Rules: E12-6-2-2-unnamed-after-named
Authority: ECMA-334 7th ed 12.6.2.2
Version: 7.3
Expected: reject
Mutate: Read(values: new int[] { 7 }, 3)
Into: Read(values: new int[] { 7 })
*/
class Program
{
    static void Read(params int[] values) { }
    static void Main() { Read(values: new int[] { 7 }, 3); }
}
