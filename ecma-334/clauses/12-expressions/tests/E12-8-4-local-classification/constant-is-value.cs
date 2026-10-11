/*
Rules: E12-8-4-local-classification; E12-8-4-local-reference
Authority: ECMA-334 7th ed 12.8.4
Version: 7.3
Expected: reject
Mutate: const int value = 3;
Into: int value = 3;
Csc: CS1510
*/
class Program
{
    static void Touch(ref int value) { value++; }
    static void Main()
    {
        const int value = 3;
        Touch(ref value);
    }
}
