/*
Rules: E9-4-4-31-outer-variable-expression-exit
Authority: ECMA-334 7th ed 9.4.4.31
Version: 7.3
Expected: reject
Mutate: int cell;
Into: int cell = 0;
Csc: CS0165
*/
class Program
{
    static void Main()
    {
        int cell;
        System.Action writer = () => cell = 73;
        System.Console.WriteLine(cell);
    }
}
