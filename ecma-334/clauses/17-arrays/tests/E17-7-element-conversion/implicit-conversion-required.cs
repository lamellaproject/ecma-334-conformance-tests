/*
Rules: E17-7-element-conversion
Authority: ECMA-334 7th ed 17.7
Version: 7.3
Expected: reject
Mutate: { 2, 3L }
Into: { 2, 3 }
*/
class Program
{
    static void Main() { int[] values = { 2, 3L }; }
}
