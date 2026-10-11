/*
Rules: E9-4-4-8-true-state-end-unassigned
Authority: ECMA-334 7th ed 9.4.4.8
Version: 7.3
Expected: reject
Mutate: int cell;
Into: int cell = 0;
Csc: CS0165
*/
class Program
{
    static int Read(bool gate)
    {
        int cell;
        while (gate && (cell = 12) > 0) gate = false;
        return cell;
    }
    static void Main() { Read(false); }
}
