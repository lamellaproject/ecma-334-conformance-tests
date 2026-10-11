/*
Rules: E12-8-9-1-dynamic-limited-check
Authority: ECMA-334 7th ed 12.8.9.1
Version: 7.3
Expected: reject
Mutate: Choose(argument, 8)
Into: Choose(argument)
*/
class Program
{
    static int Choose(int value) { return value; }
    static void Main() { dynamic argument = 5; Choose(argument, 8); }
}
