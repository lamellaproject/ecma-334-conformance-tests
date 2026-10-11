/*
Rules: E12-6-3-9-no-exact-inference
Authority: ECMA-334 7th ed 12.6.3.9
Version: 7.3
Expected: reject
Mutate: int[] values = new int[1]
Into: int[,] values = new int[1, 1]
*/
class Program
{
    static void Observe<T>(ref T[,] array) { }
    static void Main() { int[] values = new int[1]; Observe(ref values); }
}
