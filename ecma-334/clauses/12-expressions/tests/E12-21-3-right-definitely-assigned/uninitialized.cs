/*
Rules: E12-21-3-right-definitely-assigned
Authority: ECMA-334 7th ed 12.21.3
Version: 7.3
Expected: reject
Mutate: int other;
Into: int other = 4;
Csc: CS0165
*/
class Program
{
    static void Main()
    {
        int first = 3;
        int other;
        ref int alias = ref first;
        alias = ref other;
    }
}
