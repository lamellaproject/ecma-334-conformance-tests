/*
Rules: E12-18-ref-tuple-names
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
        (int kept, int other) left = (61, 67);
        (int other, int kept) right = (71, 73);
        ref var result = ref (condition ? ref left : ref right);
        int item = result.kept;
    }
}
