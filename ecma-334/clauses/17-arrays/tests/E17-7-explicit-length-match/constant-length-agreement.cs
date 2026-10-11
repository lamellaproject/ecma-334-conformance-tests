/*
Rules: E17-7-explicit-length-match
Authority: ECMA-334 7th ed 17.7
Version: 7.3
Expected: reject
Mutate: new int[2, 3]
Into: new int[2, 2]
*/
class Program
{
    static void Main() { int[,] values = new int[2, 3] { { 1, 2 }, { 3, 4 } }; }
}
