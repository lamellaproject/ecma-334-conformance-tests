/*
Rules: E13-1-embedded-no-label; E13-5-labels-not-embedded
Authority: ECMA-334 7th ed 13.1
Version: 7.3
Expected: reject
Mutate: if (true) spot: ;
Into: if (true) { spot: ; }
*/
class Program
{
    static void Main()
    {
        if (true) spot: ;
    }
}
