/*
Rules: E7-6-method-signature-no-params; E7-6-duplicate-method-signature
Authority: ECMA-334 7th ed 7.6
Version: 7.3
Expected: reject
Mutate: Read(params int[] values)
Into: Read(params long[] values)
*/
class Program
{
    static int Read(int[] values) { return 47; }
    static int Read(params int[] values) { return 53; }
    static void Main() { }
}
