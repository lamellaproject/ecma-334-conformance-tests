/*
Rules: E9-4-4-26-other-exit-unassigned
Authority: ECMA-334 7th ed 9.4.4.26
Version: 7.3
Expected: reject
Mutate: gate && other
Into: (cell = 17) > 0
Csc: CS0165
*/
class Program
{
    static int Read(bool gate, bool other)
    {
        int cell;
        bool result = gate && other;
        return cell;
    }
    static void Main() { Read(true, false); }
}
