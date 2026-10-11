/*
Rules: E7-6-method-signature-no-optionality; E7-6-duplicate-method-signature
Authority: ECMA-334 7th ed 7.6
Version: 7.3
Expected: reject
Mutate: Read(int value = 5)
Into: Read(long value = 5)
*/
class Program
{
    static int Read(int value) { return 67; }
    static int Read(int value = 5) { return 71; }
    static void Main() { }
}
