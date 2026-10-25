/*
Rules: P08-recursive-positional-tuple-names
Authority: csc 5.11.0-1.26425.128 (C# 8.0)
Version: 8.0
Expected: reject
Mutate: (value: 4, key: 7)
Into: (key: 4, value: 7)
*/
class Program
{
    static int Main()
    {
        (int key, int value) pair = (4, 7);
        return pair is (value: 4, key: 7) ? 0 : 1;
    }
}
