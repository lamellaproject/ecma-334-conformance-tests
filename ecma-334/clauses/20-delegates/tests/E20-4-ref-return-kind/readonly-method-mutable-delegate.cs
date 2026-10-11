/*
Rules: E20-4-ref-return-kind
Authority: ECMA-334 7th ed 20.4
Version: 7.3
Expected: reject
Mutate: delegate ref int Read();
Into: delegate ref readonly int Read();
*/
delegate ref int Read();
class Program
{
    static int stored;
    static ref readonly int ReadValue() { return ref stored; }
    static void Main() { Read read = ReadValue; }
}
