/*
Rules: E13-9-5-iteration-variable-scope
Authority: ECMA-334 7th ed 13.9.5
Version: 7.3
Expected: reject
Mutate: int result = item;
Into: int result = 0;
*/
class Program
{
    static void Main()
    {
        foreach (int item in new int[0]) { }
        int result = item;
    }
}
