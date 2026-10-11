/*
Rules: E12-17-implicit-argument-self-reference
Authority: ECMA-334 7th ed 12.17
Version: 7.3
Expected: reject
Mutate: out var number
Into: out int number
*/
class Program
{
    static void Fill(out int value, int other) { value = 41; }
    static void Main() { Fill(out var number, number = 3); }
}
