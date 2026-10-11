/*
Rules: E12-8-6-positional-name-conflict; E12-8-6-unnamed-type-element
Authority: ECMA-334 7th ed 12.8.6
Version: 7.3
Expected: reject
Mutate: result.Item3
Into: result.Item1
Csc: CS1061
*/
class Program
{
    static void Main()
    {
        int Item3 = 3;
        var result = (Item3, 8);
        int value = result.Item3;
    }
}
