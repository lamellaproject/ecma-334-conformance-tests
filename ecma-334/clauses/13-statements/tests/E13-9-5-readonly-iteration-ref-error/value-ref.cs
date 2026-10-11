/*
Rules: E13-9-5-readonly-iteration-ref-error
Authority: ECMA-334 7th ed 13.9.5
Version: 7.3
Expected: reject
Mutate: Change(ref item);
Into: Change(ref copy);
*/
class Program
{
    static void Change(ref int value) { value = 1; }
    static void Main()
    {
        int copy = 0;
        foreach (int item in new int[] { 4 }) { Change(ref item); }
    }
}
