/*
Rules: E9-4-4-7-controlling-expression-entry
Authority: ECMA-334 7th ed 9.4.4.7
Version: 7.3
Expected: reject
Mutate: int cell;
Into: int cell = 3;
Csc: CS0165
*/
class Program
{
    static void Main()
    {
        int cell;
        switch (cell) { case 3: break; default: break; }
    }
}
