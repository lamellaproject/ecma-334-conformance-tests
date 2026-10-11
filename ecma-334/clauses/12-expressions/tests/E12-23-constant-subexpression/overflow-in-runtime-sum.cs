/*
Rules: E12-23-constant-subexpression; E12-23-integral-arithmetic-overflow
Authority: ECMA-334 7th ed 12.23
Version: 7.3
Expected: reject
Mutate: (int.MaxValue + 1)
Into: unchecked(int.MaxValue + 1)
Csc: CS0220
*/
class Program
{
    static int Runtime() { return 6; }
    static void Main() { int result = Runtime() + (int.MaxValue + 1); }
}
