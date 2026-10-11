/*
Rules: E12-18-condition-required
Authority: ECMA-334 7th ed 12.18
Version: 7.3
Expected: reject
Mutate: condition ? left : right
Into: condition != 0 ? left : right
*/
class Program
{
    static void Main()
    {
        int condition = 1, left = 3, right = 7;
        var result = condition ? left : right;
    }
}
