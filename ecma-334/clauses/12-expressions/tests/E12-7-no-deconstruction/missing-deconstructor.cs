/*
Rules: E12-7-no-deconstruction
Authority: ECMA-334 7th ed 12.7
Version: 7.3
Expected: reject
Mutate: Extract(out int first, out int second)
Into: Deconstruct(out int first, out int second)
Csc: CS8129
*/
class Pair
{
    public void Extract(out int first, out int second) { first = 3; second = 8; }
}
class Program
{
    static void Main()
    {
        int first, second;
        (first, second) = new Pair();
    }
}
