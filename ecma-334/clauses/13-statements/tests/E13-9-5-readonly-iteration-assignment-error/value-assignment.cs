/*
Rules: E13-9-5-readonly-iteration-assignment-error; E13-9-5-value-iteration-readonly
Authority: ECMA-334 7th ed 13.9.5
Version: 7.3
Expected: reject
Mutate: item = 6;
Into: copy = 6;
*/
class Program
{
    static void Main()
    {
        int copy = 0;
        foreach (int item in new int[] { 4 }) { item = 6; }
    }
}
