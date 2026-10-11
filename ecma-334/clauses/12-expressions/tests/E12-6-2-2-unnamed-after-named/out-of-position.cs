/*
Rules: E12-6-2-2-unnamed-after-named
Authority: ECMA-334 7th ed 12.6.2.2
Version: 7.3
Expected: reject
Mutate: Read(last: 7, 3)
Into: Read(last: 7, first: 3)
*/
class Program
{
    static void Read(int first = 11, int last = 17) { }
    static void Main() { Read(last: 7, 3); }
}
