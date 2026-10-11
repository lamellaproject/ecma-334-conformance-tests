/*
Rules: E13-8-3-pattern-applicability-required
Authority: ECMA-334 7th ed 13.8.3
Version: 7.3
Expected: reject
Mutate: case "token":
Into: case 5:
*/
class Program
{
    static void Main()
    {
        int selector = 5;
        switch (selector) { case "token": break; default: break; }
    }
}
