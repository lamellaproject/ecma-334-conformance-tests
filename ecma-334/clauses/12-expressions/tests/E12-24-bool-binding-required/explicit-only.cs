/*
Rules: E12-24-bool-binding-required
Authority: ECMA-334 7th ed 12.24
Version: 7.3
Expected: reject
Mutate: if (new Flag())
Into: if ((bool)new Flag())
Csc: CS0266
*/
class Flag
{
    public static explicit operator bool(Flag flag) { return true; }
}
class Program
{
    static void Main() { if (new Flag()) { } }
}
