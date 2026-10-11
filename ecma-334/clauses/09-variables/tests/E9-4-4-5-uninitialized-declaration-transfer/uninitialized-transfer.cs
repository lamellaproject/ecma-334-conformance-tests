/*
Rules: E9-4-4-5-uninitialized-declaration-transfer
Authority: ECMA-334 7th ed 9.4.4.5
Version: 7.3
Expected: reject
Mutate: int cell;
Into: int cell = 45;
Csc: CS0165
*/
class Program
{
    static void Main()
    {
        int cell;
        int another;
        System.Console.WriteLine(cell);
        another = 5;
    }
}
