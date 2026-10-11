/*
Rules: E13-8-3-no-fall-through; E13-2-switch-list-end-error
Authority: ECMA-334 7th ed 13.8.3
Version: 7.3
Expected: reject
Mutate: case 4: value = 1;
Into: case 4: value = 1; break;
*/
class Program
{
    static void Main()
    {
        int selector = 4;
        int value = 0;
        switch (selector)
        {
            case 4: value = 1;
            default: value = 2; break;
        }
    }
}
