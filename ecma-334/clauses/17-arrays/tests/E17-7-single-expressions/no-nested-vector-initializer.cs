/*
Rules: E17-7-single-expressions
Authority: ECMA-334 7th ed 17.7
Version: 7.3
Expected: reject
Mutate: { { 3, 8 } }
Into: { 3, 8 }
*/
class Program
{
    static void Main() { int[] values = { { 3, 8 } }; }
}
