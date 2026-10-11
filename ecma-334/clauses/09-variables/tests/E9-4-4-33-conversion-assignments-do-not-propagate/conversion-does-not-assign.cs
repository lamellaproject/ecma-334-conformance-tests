/*
Rules: E9-4-4-33-conversion-assignments-do-not-propagate
Authority: ECMA-334 7th ed 9.4.4.33
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
        void Fill() { cell = 29; }
        System.Action writer = Fill;
        System.Console.WriteLine(cell);
    }
}
