/*
Rules: E6-3-4-grammar-whitespace-1
Authority: ECMA-334 7th ed 6.3.4
Version: 7.3
Expected: reject
Mutate: 13\xE2\x80\x8B+ 29
Into: 13 + 29
*/
class Program
{
    static void Main()
    {
        int sum = 13​+ 29;
    }
}
