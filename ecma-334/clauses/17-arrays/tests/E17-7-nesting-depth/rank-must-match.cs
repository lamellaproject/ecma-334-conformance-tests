/*
Rules: E17-7-nesting-depth
Authority: ECMA-334 7th ed 17.7
Version: 7.3
Expected: reject
Mutate: { 3, 7 }
Into: { { 3, 7 } }
*/
class Program
{
    static void Main() { int[,] values = { 3, 7 }; }
}
