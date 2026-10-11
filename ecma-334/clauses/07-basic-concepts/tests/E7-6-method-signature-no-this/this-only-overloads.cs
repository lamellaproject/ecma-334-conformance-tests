/*
Rules: E7-6-method-signature-no-this; E7-6-duplicate-method-signature
Authority: ECMA-334 7th ed 7.6
Version: 7.3
Expected: reject
Mutate: Read(this int value)
Into: Other(this int value)
*/
static class Operations
{
    public static int Read(int value) { return 59; }
    public static int Read(this int value) { return 61; }
}
class Program { static void Main() { } }
