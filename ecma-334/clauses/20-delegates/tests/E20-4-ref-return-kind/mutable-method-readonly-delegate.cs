/*
Rules: E20-4-ref-return-kind
Authority: ECMA-334 7th ed 20.4
Version: 7.3
Expected: reject
Mutate: delegate ref readonly int Read();
Into: delegate ref int Read();
*/
delegate ref readonly int Read();
class Program
{
    static int stored;
    static ref int ReadValue() { return ref stored; }
    static void Main() { Read read = ReadValue; }
}
