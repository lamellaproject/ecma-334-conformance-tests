/*
Rules: E7-6-method-type-parameter-ordinal; E7-6-method-signature-no-type-parameter-names; E7-6-duplicate-method-signature
Authority: ECMA-334 7th ed 7.6
Version: 7.3
Expected: reject
Mutate: Read<X, Y>(X first, Y second)
Into: Read<X, Y>(Y first, X second)
*/
class Program
{
    static int Read<T, U>(T first, U second) { return 17; }
    static int Read<X, Y>(X first, Y second) { return 19; }
    static void Main() { }
}
