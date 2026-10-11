/*
Rules: E12-23-constant-pattern-context
Authority: ECMA-334 7th ed 12.23
Version: 7.3
Expected: reject
Mutate: number is target
Into: number is 7
Csc: CS9135
*/
class Program
{
    static void Main() { int number = 7, target = 7; if (number is target) { } }
}
