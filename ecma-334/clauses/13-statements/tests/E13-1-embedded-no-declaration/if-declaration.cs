/*
Rules: E13-1-embedded-no-declaration; E13-6-1-declarations-not-embedded
Authority: ECMA-334 7th ed 13.1
Version: 7.3
Expected: reject
Mutate: if (true) int chip = 4;
Into: if (true) { int chip = 4; }
*/
class Program
{
    static void Main()
    {
        if (true) int chip = 4;
    }
}
