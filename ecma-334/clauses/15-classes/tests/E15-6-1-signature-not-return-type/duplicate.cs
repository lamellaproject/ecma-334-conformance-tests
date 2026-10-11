/*
Rules: E15-6-1-signature-not-return-type; E15-6-1-method-duplicate-signature
Authority: ECMA-334 7th ed 15.6.1
Version: 7.3
Expected: reject
Mutate: public long Read(int value)
Into: public long Inspect(int value)
Csc: CS0111
*/
class Holder
{
    public int Read(int value) { return 1; }
    public long Read(int value) { return 2; }
}
class Program { static void Main() { } }
