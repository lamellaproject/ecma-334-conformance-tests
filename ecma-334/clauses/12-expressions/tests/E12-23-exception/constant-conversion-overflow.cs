/*
Rules: E12-23-exception; E12-23-integral-conversion-overflow
Authority: ECMA-334 7th ed 12.23
Version: 7.3
Expected: reject
Mutate: const byte Value = (byte)300;
Into: const byte Value = unchecked((byte)300);
Csc: CS0221
*/
class Program
{
    const byte Value = (byte)300;
    static void Main() { }
}
