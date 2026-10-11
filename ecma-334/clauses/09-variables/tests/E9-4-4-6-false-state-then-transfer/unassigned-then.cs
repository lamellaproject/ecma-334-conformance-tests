/*
Rules: E9-4-4-6-false-state-then-transfer
Authority: ECMA-334 7th ed 9.4.4.6
Version: 7.3
Expected: reject
Mutate: if (gate || (cell = 15) < 0) return cell;
Into: if (gate || (cell = 15) < 0) return 0;
Csc: CS0165
*/
class Program
{
    static int Read(bool gate)
    {
        int cell;
        if (gate || (cell = 15) < 0) return cell;
        return -1;
    }
    static void Main() { Read(true); }
}
