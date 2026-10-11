/*
Rules: E7-7-1-local-constant-before-declarator
Authority: ECMA-334 7th ed 7.7.1
Version: 7.3
Expected: reject
Mutate: int before = value;
Into: int before = 167;
*/
class Program
{
    static void Main()
    {
        int before = value;
        const int value = 167;
    }
}
