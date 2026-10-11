/*
Rules: E7-6-method-signature-no-constraints; E7-6-duplicate-method-signature
Authority: ECMA-334 7th ed 7.6
Version: 7.3
Expected: reject
Mutate: Read<U>(U value) where U : struct
Into: Other<U>(U value) where U : struct
*/
class Program
{
    static int Read<T>(T value) where T : class { return 41; }
    static int Read<U>(U value) where U : struct { return 43; }
    static void Main() { }
}
