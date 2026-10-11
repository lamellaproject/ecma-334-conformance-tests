/*
Rules: E13-6-2-1-local-before-declarator
Authority: ECMA-334 7th ed 13.6.2.1
Version: 7.3
Expected: reject
Mutate: value = 7;
Into: ;
*/
class Program
{
    static void Main()
    {
        // An assignment does not read an unassigned value.
        value = 7;
        int value = 2;
    }
}
