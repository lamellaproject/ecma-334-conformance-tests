/*
Rules: E15-6-1-signature-not-parameter-names; E15-6-1-method-duplicate-signature
Authority: ECMA-334 7th ed 15.6.1
Version: 7.3
Expected: reject
Mutate: public int Read(int second)
Into: public int Inspect(int second)
Csc: CS0111
*/
class Holder
{
    public int Read(int first) { return 1; }
    public int Read(int second) { return 2; }
}
class Program { static void Main() { } }
