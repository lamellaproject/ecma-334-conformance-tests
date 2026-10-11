/*
Rules: E13-6-2-1-local-own-initializer
Authority: ECMA-334 7th ed 13.6.2.1
Version: 7.3
Expected: reject
Version-Witness: version-witnesses/self-assignment-0bdce0a342.cs.part
Mutate: int value = (value = 7);
Into: int value = 7;
*/
class Program
{
    // The reference assigns the variable; it does not read an unassigned value.
    static void Main() { int value = (value = 7); }
}
