/*
Rules: E12-6-3-2-explicit-in-first-phase; E12-6-3-9-exact-bound
Authority: ECMA-334 7th ed 12.6.3.2
Version: 7.3
Expected: reject
Mutate: Merge(7L, in value)
Into: Merge(7L, value)
*/
class Program
{
    static T Merge<T>(T first, in T second) { return first; }
    static void Main() { int value = 5; Merge(7L, in value); }
}
