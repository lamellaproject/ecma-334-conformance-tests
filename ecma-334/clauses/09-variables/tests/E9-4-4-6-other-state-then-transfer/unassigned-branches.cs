/*
Rules: E9-4-4-6-other-state-then-transfer; E9-4-4-6-other-state-false-transfer
Authority: ECMA-334 7th ed 9.4.4.6
Version: 7.3
Expected: reject
Mutate: int cell;
Into: int cell = 8;
Csc: CS0165
*/
class Program
{
    static int Read(bool gate)
    {
        int cell;
        if (gate) return cell;
        else return cell;
    }
    static void Main() { Read(true); }
}
