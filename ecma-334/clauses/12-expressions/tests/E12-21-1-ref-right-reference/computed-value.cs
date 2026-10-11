/*
Rules: E12-21-1-ref-right-reference
Authority: ECMA-334 7th ed 12.21.1
Version: 7.3
Expected: reject
Mutate: alias = ref (other + 1)
Into: alias = ref other
Csc: CS1510
*/
class Program
{
    static void Main()
    {
        int first = 3, other = 7;
        ref int alias = ref first;
        alias = ref (other + 1);
    }
}
