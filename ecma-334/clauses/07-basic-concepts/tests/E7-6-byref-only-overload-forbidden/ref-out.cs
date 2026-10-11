/*
Rules: E7-6-byref-only-overload-forbidden
Authority: ECMA-334 7th ed 7.6
Version: 7.3
Expected: reject
Mutate: Read(out int value)
Into: Read(out long value)
*/
class Program
{
    static int Read(ref int value) { return value; }
    static int Read(out int value) { value = 139; return 149; }
    static void Main() { }
}
