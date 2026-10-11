/*
Rules: E7-3-switch-direct-local-space; E7-3-statement-local-spaces
Authority: ECMA-334 7th ed 7.3
Version: 7.3
Expected: reject
Mutate: int value = 23;
Into: int other = 23;
*/
class Program
{
    static void Select(int choice)
    {
        switch (choice)
        {
            case 0: int value = 17; break;
            case 1: int value = 23; break;
        }
    }
    static void Main() { Select(0); }
}
