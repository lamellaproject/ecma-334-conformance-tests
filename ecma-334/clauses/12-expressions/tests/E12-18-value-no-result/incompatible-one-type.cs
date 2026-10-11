/*
Rules: E12-18-value-no-result
Authority: ECMA-334 7th ed 12.18
Version: 7.3
Expected: reject
Mutate: (() => 41)
Into: 41
*/
class Program
{
    static void Main()
    {
        bool condition = false;
        int number = 37;
        var result = condition ? number : (() => 41);
    }
}
