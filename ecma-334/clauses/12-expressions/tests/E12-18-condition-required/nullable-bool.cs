/*
Rules: E12-18-condition-required
Authority: ECMA-334 7th ed 12.18
Version: 7.3
Expected: reject
Mutate: condition ? left : right
Into: condition.GetValueOrDefault() ? left : right
*/
class Program
{
    static void Main()
    {
        bool? condition = true;
        int left = 11, right = 13;
        var result = condition ? left : right;
    }
}
