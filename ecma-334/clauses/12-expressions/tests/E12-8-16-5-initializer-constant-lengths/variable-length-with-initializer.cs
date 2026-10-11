/*
Rules: E12-8-16-5-initializer-constant-lengths
Authority: ECMA-334 7th ed 12.8.16.5
Version: 7.3
Expected: reject
Mutate: new int[count] { 7, 19 }
Into: new int[2] { 7, 19 }
*/
class Program
{
    static void Main()
    {
        int count = 2;
        var cells = new int[count] { 7, 19 };
    }
}
