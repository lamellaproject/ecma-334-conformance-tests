/*
Rules: E12-21-3-left-target-kinds
Authority: ECMA-334 7th ed 12.21.3
Version: 7.3
Expected: reject
Mutate: ordinary = ref other
Into: alias = ref other
Csc: CS8373
*/
class Program
{
    static void Main()
    {
        int ordinary = 3, other = 7;
        ref int alias = ref ordinary;
        ordinary = ref other;
    }
}
