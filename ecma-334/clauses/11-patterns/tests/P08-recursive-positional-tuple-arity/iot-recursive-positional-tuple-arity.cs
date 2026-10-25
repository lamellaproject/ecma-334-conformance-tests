/*
Rules: P08-recursive-positional-tuple-arity
Authority: csc 5.11.0-1.26425.128 (C# 8.0)
Version: 8.0
Expected: reject
Mutate: (4, 7, 9)
Into: (4, 7)
*/
class Program
{
    static int Main()
    {
        (int, int) pair = (4, 7);
        return pair is (4, 7, 9) ? 0 : 1;
    }
}
