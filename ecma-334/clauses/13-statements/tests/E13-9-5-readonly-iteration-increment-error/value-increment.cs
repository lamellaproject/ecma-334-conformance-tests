/*
Rules: E13-9-5-readonly-iteration-increment-error
Authority: ECMA-334 7th ed 13.9.5
Version: 7.3
Expected: reject
Mutate: item++;
Into: copy++;
*/
class Program
{
    static void Main()
    {
        int copy = 0;
        foreach (int item in new int[] { 4 }) { item++; }
    }
}
