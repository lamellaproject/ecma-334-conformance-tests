/*
Rules: E12-8-2-literal-value
Authority: ECMA-334 7th ed 12.8.2
Version: 7.3
Expected: reject
Mutate: Touch(ref 37);
Into: Touch(ref value);
Csc: CS1510
*/
class Program
{
    static void Touch(ref int value) { value++; }
    static void Main()
    {
        int value = 37;
        Touch(ref 37);
    }
}
