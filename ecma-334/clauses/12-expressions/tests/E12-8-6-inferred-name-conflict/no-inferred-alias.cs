/*
Rules: E12-8-6-inferred-name-conflict; E12-8-6-unnamed-type-element
Authority: ECMA-334 7th ed 12.8.6
Version: 7.3
Expected: reject
Mutate: result.named
Into: result.Item1
Csc: CS1061
*/
class Pair { public int named; }
class Program
{
    static void Main()
    {
        Pair first = new Pair { named = 3 }, second = new Pair { named = 8 };
        var result = (first.named, second.named);
        int value = result.named;
    }
}
