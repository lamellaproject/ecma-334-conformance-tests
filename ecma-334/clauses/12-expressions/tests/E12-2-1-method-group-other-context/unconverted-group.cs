/*
Rules: E12-2-1-method-group-other-context; E12-2-2-value-required
Authority: ECMA-334 7th ed 12.2.1
Version: 7.3
Expected: reject
Mutate: int value = Read;
Into: int value = Read();
*/
class Program
{
    static int Read() { return 32; }
    static void Main() { int value = Read; }
}
