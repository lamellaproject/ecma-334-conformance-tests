/*
Rules: E12-18-ref-no-throw
Authority: ECMA-334 7th ed 12.18
Version: 7.3
Expected: reject
Mutate: throw new System.Exception()
Into: ref right
*/
class Program
{
    static void Main()
    {
        bool condition = true;
        int left = 17, right = 19;
        ref int result = ref (condition ? ref left : throw new System.Exception());
    }
}
