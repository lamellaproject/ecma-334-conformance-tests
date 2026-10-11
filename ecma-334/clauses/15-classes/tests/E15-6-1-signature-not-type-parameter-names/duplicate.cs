/*
Rules: E15-6-1-signature-not-type-parameter-names; E15-6-1-signature-type-parameter-position; E15-6-1-method-duplicate-signature
Authority: ECMA-334 7th ed 15.6.1
Version: 7.3
Expected: reject
Mutate: public int Read<A, B>(A first, B second)
Into: public int Read<A, B>(B first, A second)
Csc: CS0111
*/
class Holder
{
    public int Read<T, U>(T first, U second) { return 1; }
    public int Read<A, B>(A first, B second) { return 2; }
}
class Program { static void Main() { } }
