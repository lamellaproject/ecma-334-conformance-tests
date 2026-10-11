/*
Rules: E6-4-2-escape-context-restriction
Authority: ECMA-334 7th ed 6.4.2
Version: 7.3
Expected: reject
Mutate: \u002B
Into: +
*/
class Program
{
    static void Main() { int result = 17 \u002B 9; }
}
