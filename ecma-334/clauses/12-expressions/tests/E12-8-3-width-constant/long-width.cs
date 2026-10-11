/*
Rules: E12-8-3-width-constant
Authority: ECMA-334 7th ed 12.8.3
Version: 7.3
Expected: reject
Mutate: const long width = 4;
Into: const int width = 4;
Csc: CS0266
*/
class Program
{
    static void Main()
    {
        const long width = 4;
        string result = $"v{3,width}";
    }
}
