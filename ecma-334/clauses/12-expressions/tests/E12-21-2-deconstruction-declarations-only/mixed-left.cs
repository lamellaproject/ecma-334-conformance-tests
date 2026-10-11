/*
Rules: E12-21-2-deconstruction-declarations-only
Authority: ECMA-334 7th ed 12.21.2
Version: 7.3
Expected: reject
Mutate: (var fresh, existing)
Into: (var fresh, var next)
Csc: CS8370
*/
class Program
{
    static void Main() { int existing = 0; (var fresh, existing) = (3, 4); }
}
