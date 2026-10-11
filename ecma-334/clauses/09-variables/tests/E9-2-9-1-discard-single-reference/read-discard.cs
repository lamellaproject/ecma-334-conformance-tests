/*
Rules: E9-2-9-1-discard-single-reference; E9-2-9-1-discard-read; E9-2-9-1-discard-initially-unassigned
Authority: ECMA-334 7th ed 9.2.9.1
Version: 7.3
Expected: reject
Mutate: int result = _;
Into: int result = 17;
Csc: CS0103
*/
class Program
{
    static void Fill(out int cell) { cell = 17; }
    static void Main()
    {
        Fill(out int _);
        int result = _;
    }
}
