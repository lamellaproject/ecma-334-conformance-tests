/*
Rules: E12-8-3-width-constant
Authority: ECMA-334 7th ed 12.8.3
Version: 7.3
Expected: reject
Mutate: $"v{3,width}"
Into: $"v{3,4}"
Csc: CS0150
*/
class Program
{
    static void Main()
    {
        int width = 4;
        string result = $"v{3,width}";
    }
}
