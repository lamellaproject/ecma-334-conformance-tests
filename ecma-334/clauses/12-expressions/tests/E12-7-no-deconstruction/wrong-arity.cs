/*
Rules: E12-7-no-deconstruction; E12-7-deconstructor-selection
Authority: ECMA-334 7th ed 12.7
Version: 7.3
Expected: reject
Mutate: (first, second) = new Pair();
Into: (first, second, third) = new Pair();
Csc: CS8129
*/
class Pair
{
    public void Deconstruct(out int first, out int second, out int third) { first = 3; second = 8; third = 9; }
}
class Program
{
    static void Main()
    {
        int first, second, third;
        (first, second) = new Pair();
    }
}
