/*
Rules: E12-18-ref-arm-identity-required
Authority: ECMA-334 7th ed 12.18
Version: 7.3
Expected: reject
Mutate: long right = 23;
Into: int right = 23;
*/
class Program
{
    static void Main()
    {
        bool condition = true;
        int left = 19;
        long right = 23;
        ref var result = ref (condition ? ref left : ref right);
    }
}
