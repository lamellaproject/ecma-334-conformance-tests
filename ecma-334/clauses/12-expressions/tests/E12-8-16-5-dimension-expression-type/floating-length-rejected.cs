/*
Rules: E12-8-16-5-dimension-expression-type
Authority: ECMA-334 7th ed 12.8.16.5
Version: 7.3
Expected: reject
Mutate: new int[length]
Into: new int[(int)length]
*/
class Program
{
    static void Main()
    {
        double length = 3;
        var cells = new int[length];
    }
}
