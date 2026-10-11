/*
Rules: E13-10-5-value-return-conversion-required
Authority: ECMA-334 7th ed 13.10.5
Version: 7.3
Expected: reject
Mutate: return value;
Into: return (int)value;
*/

class Program
{
    static int Narrow(long value) { return value; }
    static void Main() { }
}
