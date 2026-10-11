/*
Rules: E12-8-7-1-constant-value
Authority: ECMA-334 7th ed 12.8.7.1
Version: 7.3
Expected: reject
Mutate: Touch(ref Worker.Value);
Into: Touch(ref copy);
Csc: CS1510
*/
class Worker { public const int Value = 3; }
class Program
{
    static void Touch(ref int value) { value++; }
    static void Main()
    {
        int copy = Worker.Value;
        Touch(ref Worker.Value);
    }
}
