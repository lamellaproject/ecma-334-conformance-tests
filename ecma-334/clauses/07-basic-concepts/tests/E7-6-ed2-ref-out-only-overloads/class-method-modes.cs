/*
Rules: E7-6-ed2-ref-out-only-overloads
Authority: ECMA-334 2nd ed 10.6
Version: ISO-1
Expected: reject
Mutate: Carry(out int cargo)
Into: Carry(out long cargo)
*/
class MethodRack
{
    public static void Carry(ref int cargo) {}
    public static void Carry(out int cargo) { cargo = 6; }
    static void Main() {}
}
