/*
Rules: E13-6-2-1-local-before-declarator
Authority: ECMA-334 7th ed 13.6.2.1
Version: 7.3
Expected: reject
Mutate: int total = chip;
Into: int total = 4;
*/
class Program
{
    static void Main()
    {
        int total = chip;
        int chip = 4;
    }
}
