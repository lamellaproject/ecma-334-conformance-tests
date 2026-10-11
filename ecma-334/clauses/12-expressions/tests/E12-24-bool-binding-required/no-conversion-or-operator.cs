/*
Rules: E12-24-bool-binding-required
Authority: ECMA-334 7th ed 12.24
Version: 7.3
Expected: reject
Mutate: if (new Flag())
Into: if (new Flag() != null)
Csc: CS0029
*/
class Flag { }
class Program
{
    static void Main() { if (new Flag()) { } }
}
