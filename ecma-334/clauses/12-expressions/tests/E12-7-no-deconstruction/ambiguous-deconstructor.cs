/*
Rules: E12-7-no-deconstruction; E12-7-deconstructor-selection
Authority: ECMA-334 7th ed 12.7
Version: 7.3
Expected: reject
Mutate: Deconstruct(out long first, out long second)
Into: Extract(out long first, out long second)
Csc: CS0121
*/
class Pair
{
    public void Deconstruct(out int first, out int second) { first = 3; second = 8; }
    public void Deconstruct(out long first, out long second) { first = 5; second = 9; }
}
class Program
{
    static void Main()
    {
        int first, second;
        (first, second) = new Pair();
    }
}
