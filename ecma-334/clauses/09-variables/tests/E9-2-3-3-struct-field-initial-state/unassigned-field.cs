/*
Rules: E9-2-3-3-struct-field-initial-state; E9-4-3-struct-field-unassigned
Authority: ECMA-334 7th ed 9.2.3.3
Version: 7.3
Expected: reject
Mutate: pair.Left = 7;
Into: pair.Left = 7; pair.Right = 12;
Csc: CS0170
*/
struct Pair { public int Left, Right; }
class Program
{
    static void Main()
    {
        Pair pair;
        pair.Left = 7;
        System.Console.WriteLine(pair.Right);
    }
}
