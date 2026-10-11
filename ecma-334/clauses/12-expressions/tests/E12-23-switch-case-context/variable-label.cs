/*
Rules: E12-23-switch-case-context
Authority: ECMA-334 7th ed 12.23
Version: 7.3
Expected: reject
Mutate: case label:
Into: case 2:
Csc: CS9135
*/
class Program
{
    static void Main() { int selector = 1, label = 2; switch (selector) { case label: break; } }
}
