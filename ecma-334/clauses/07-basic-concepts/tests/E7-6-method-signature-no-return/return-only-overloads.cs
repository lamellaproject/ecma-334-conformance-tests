/*
Rules: E7-6-method-signature-no-return; E7-6-duplicate-method-signature
Authority: ECMA-334 7th ed 7.6
Version: 7.3
Expected: reject
Mutate: static long Read(int value)
Into: static long Other(int value)
*/
class Program
{
    static int Read(int value) { return 23; }
    static long Read(int value) { return 29; }
    static void Main() { }
}
