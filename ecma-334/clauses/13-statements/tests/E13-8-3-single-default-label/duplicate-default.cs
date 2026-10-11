/*
Rules: E13-8-3-single-default-label
Authority: ECMA-334 7th ed 13.8.3
Version: 7.3
Expected: reject
Mutate: default: ; break;
Into: case 3: ; break;
*/
class Program
{
    static void Main()
    {
        int selector = 1;
        switch (selector) { default: break; default: ; break; }
    }
}
