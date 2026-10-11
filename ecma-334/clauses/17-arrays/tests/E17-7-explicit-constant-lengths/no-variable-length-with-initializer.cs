/*
Rules: E17-7-explicit-constant-lengths
Authority: ECMA-334 7th ed 17.7
Version: 7.3
Expected: reject
Mutate: new int[size]
Into: new int[2]
*/
class Program
{
    static void Main()
    {
        int size = 2;
        int[] values = new int[size] { 6, 7 };
    }
}
