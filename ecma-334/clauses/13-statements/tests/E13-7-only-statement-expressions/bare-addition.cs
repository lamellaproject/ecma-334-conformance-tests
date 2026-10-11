/*
Rules: E13-7-only-statement-expressions
Authority: ECMA-334 7th ed 13.7
Version: 7.3
Expected: reject
Mutate: value + 2;
Into: value = value + 2;
*/
class Program
{
    static void Main() { int value = 4; value + 2; }
}
