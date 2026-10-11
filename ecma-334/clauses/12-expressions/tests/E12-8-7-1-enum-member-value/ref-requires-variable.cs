/*
Rules: E12-8-7-1-enum-member-value
Authority: ECMA-334 7th ed 12.8.7.1
Version: 7.3
Expected: reject
Mutate: Touch(ref Mode.Chosen);
Into: Touch(ref copy);
Csc: CS1510
*/
enum Mode { Chosen = 3, Other = 8 }
class Program
{
    static void Touch(ref Mode value) { value = Mode.Other; }
    static void Main()
    {
        Mode copy = Mode.Chosen;
        Touch(ref Mode.Chosen);
    }
}
