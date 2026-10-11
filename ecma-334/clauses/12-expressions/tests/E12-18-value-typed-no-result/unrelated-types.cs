/*
Rules: E12-18-value-typed-no-result
Authority: ECMA-334 7th ed 12.18
Version: 7.3
Expected: reject
Mutate: condition ? number : text
Into: condition ? number : 31
*/
class Program
{
    static void Main()
    {
        bool condition = true;
        int number = 29;
        string text = "text";
        var result = condition ? number : text;
    }
}
