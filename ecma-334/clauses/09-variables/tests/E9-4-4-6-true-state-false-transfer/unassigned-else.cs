/*
Rules: E9-4-4-6-true-state-false-transfer
Authority: ECMA-334 7th ed 9.4.4.6
Version: 7.3
Expected: reject
Mutate: else return cell;
Into: else return -1;
Csc: CS0165
*/
class Program
{
    static int Read(bool gate)
    {
        int cell;
        if (gate && (cell = 32) > 0) return 1;
        else return cell;
    }
    static void Main() { Read(false); }
}
