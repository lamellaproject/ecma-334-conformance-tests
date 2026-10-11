/*
Rules: E12-18-value-no-result
Authority: ECMA-334 7th ed 12.18
Version: 7.3
Expected: reject
Mutate: condition ? null : null
Into: condition ? (object)null : null
*/
class Program
{
    static void Main()
    {
        bool condition = true;
        var result = condition ? null : null;
    }
}
