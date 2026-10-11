/*
Rules: E12-21-1-no-direct-declaration
Authority: ECMA-334 7th ed 12.21.1
Version: 7.3
Expected: reject
Mutate: (var fresh) = 4
Into: (existing) = 4
Csc: CS1073
*/
class Program
{
    static void Main() { int existing = 0; (var fresh) = 4; }
}
