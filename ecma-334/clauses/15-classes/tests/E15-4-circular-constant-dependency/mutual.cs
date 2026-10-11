/*
Rules: E15-4-circular-constant-dependency
Authority: ECMA-334 7th ed 15.4
Version: 7.3
Expected: reject
Mutate: public const int Second = First - 7;
Into: public const int Second = 79;
Csc: CS0110
*/
class Limits
{
    public const int First = Second + 7;
    public const int Second = First - 7;
}
class Program { static void Main() { int value = Limits.First; } }
