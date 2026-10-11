/*
Rules: E7-3-body-local-space; E7-3-nested-local-name-conflict
Authority: ECMA-334 7th ed 7.3
Version: 7.3
Expected: reject
Mutate: int Nested(int value)
Into: int Nested(int input)
*/
class Program
{
    static void Main()
    {
        int Nested(int value) { int value = 17; return value; }
        Nested(23);
    }
}
