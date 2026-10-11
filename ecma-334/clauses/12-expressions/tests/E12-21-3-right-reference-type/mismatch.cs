/*
Rules: E12-21-3-right-reference-type
Authority: ECMA-334 7th ed 12.21.3
Version: 7.3
Expected: reject
Mutate: alias = ref wide
Into: alias = ref narrow
Csc: CS8173
*/
class Program
{
    static void Main()
    {
        int first = 3, narrow = 7;
        long wide = 9L;
        ref int alias = ref first;
        alias = ref wide;
    }
}
