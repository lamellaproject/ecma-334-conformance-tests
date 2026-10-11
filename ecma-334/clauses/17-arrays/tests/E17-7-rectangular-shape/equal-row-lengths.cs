/*
Rules: E17-7-rectangular-shape
Authority: ECMA-334 7th ed 17.7
Version: 7.3
Expected: reject
Mutate: { { 1, 2 }, { 3 } }
Into: { { 1, 2 }, { 3, 4 } }
*/
class Program
{
    static void Main() { int[,] values = { { 1, 2 }, { 3 } }; }
}
