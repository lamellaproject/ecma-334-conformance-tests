/*
Rules: E12-18-value-tuple-names
Authority: ECMA-334 7th ed 12.18
Version: 7.3
Expected: reject
Mutate: result.kept
Into: result.Item1
*/
class Program
{
    static void Main()
    {
        bool condition = true;
        (int kept, int other) left = (43, 47);
        (int other, int kept) right = (53, 59);
        var result = condition ? left : right;
        int item = result.kept;
    }
}
