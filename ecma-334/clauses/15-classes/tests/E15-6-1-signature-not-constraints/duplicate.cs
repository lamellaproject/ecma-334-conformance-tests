/*
Rules: E15-6-1-signature-not-constraints; E15-6-1-method-duplicate-signature
Authority: ECMA-334 7th ed 15.6.1
Version: 7.3
Expected: reject
Mutate: public int Read<T>(T value) where T : struct
Into: public int Inspect<T>(T value) where T : struct
Csc: CS0111
*/
class Holder
{
    public int Read<T>(T value) where T : class { return 1; }
    public int Read<T>(T value) where T : struct { return 2; }
}
class Program { static void Main() { } }
