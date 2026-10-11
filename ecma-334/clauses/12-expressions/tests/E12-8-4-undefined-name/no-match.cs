/*
Rules: E12-8-4-undefined-name
Authority: ECMA-334 7th ed 12.8.4
Version: 7.3
Expected: reject
Mutate: missing = 3;
Into: value = 3;
Csc: CS0103
*/
class Program
{
    static void Main()
    {
        int value = 0;
        missing = 3;
    }
}
