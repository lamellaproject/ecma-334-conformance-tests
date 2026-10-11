/*
Rules: E7-3-local-declare-before-use; E7-7-1-local-before-declarator
Authority: ECMA-334 7th ed 7.3
Version: 7.3
Expected: reject
Mutate: int copy = value;
Into: int copy = 17;
*/
class Program
{
    static void Main()
    {
        int copy = value;
        int value = 17;
    }
}
