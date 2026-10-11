/*
Rules: E7-6-signature-equality; E7-6-duplicate-method-signature
Authority: ECMA-334 7th ed 7.6
Version: 7.3
Expected: reject
Mutate: Read(System.Int32 value)
Into: Read(System.Int64 value)
*/
class Program
{
    static int Read(int value) { return 107; }
    static int Read(System.Int32 value) { return 109; }
    static void Main() { }
}
