/*
Rules: E7-6-method-signature-no-parameter-names; E7-6-duplicate-method-signature
Authority: ECMA-334 7th ed 7.6
Version: 7.3
Expected: reject
Mutate: Read(int second)
Into: Read(long second)
*/
class Program
{
    static int Read(int first) { return 31; }
    static int Read(int second) { return 37; }
    static void Main() { }
}
