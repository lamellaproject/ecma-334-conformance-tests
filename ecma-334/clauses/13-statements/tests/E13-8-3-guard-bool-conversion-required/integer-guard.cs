/*
Rules: E13-8-3-guard-bool-conversion-required
Authority: ECMA-334 7th ed 13.8.3
Version: 7.3
Expected: reject
Mutate: case 1 when 4:
Into: case 1 when true:
*/
class Program
{
    static void Main()
    {
        int value = 1;
        switch (value) { case 1 when 4: break; }
    }
}
