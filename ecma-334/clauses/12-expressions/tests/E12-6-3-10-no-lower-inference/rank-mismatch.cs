/*
Rules: E12-6-3-10-no-lower-inference
Authority: ECMA-334 7th ed 12.6.3.10
Version: 7.3
Expected: reject
Mutate: new int[1]
Into: new int[1, 1]
*/
class Program
{
    static void Observe<T>(T[,] value) { }
    static void Main() { Observe(new int[1]); }
}
