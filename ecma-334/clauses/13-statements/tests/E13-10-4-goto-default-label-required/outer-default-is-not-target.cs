/*
Rules: E13-10-4-goto-default-label-required
Authority: ECMA-334 7th ed 13.10.4
Version: 7.3
Expected: reject
Mutate: goto default;
Into: break;
*/
class Program
{
    static void Main()
    {
        int value = 0;
        switch (value)
        {
            default: switch (value) { case 0: goto default; } break;
        }
    }
}
