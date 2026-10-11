/*
Rules: E12-21-2-deconstruction-no-element-names
Authority: ECMA-334 7th ed 12.21.2
Version: 7.3
Expected: reject
Mutate: (label: first, second)
Into: (first, second)
Csc: CS8187
*/
class Program
{
    static void Main() { int first = 0, second = 0; (label: first, second) = (3, 4); }
}
