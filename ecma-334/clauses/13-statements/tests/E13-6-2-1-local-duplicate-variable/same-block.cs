/*
Rules: E13-6-2-1-local-duplicate-variable
Authority: ECMA-334 7th ed 13.6.2.1
Version: 7.3
Expected: reject
Mutate: int chip = 5;
Into: int other = 5;
*/
class Program
{
    static void Main()
    {
        int chip = 4;
        int chip = 5;
    }
}
