/*
Rules: E13-10-4-goto-case-matching-label-required
Authority: ECMA-334 7th ed 13.10.4
Version: 7.3
Expected: reject
Mutate: goto case 2;
Into: goto case 1;
*/
class Program
{
    static void Main()
    {
        int value = 0;
        switch (value)
        {
            case 0: switch (value) { case 0: goto case 2; case 1: break; } break;
            case 2: break;
        }
    }
}
