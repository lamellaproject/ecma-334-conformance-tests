/*
Rules: E6-4-5-3-integer-overflow
Authority: ECMA-334 7th ed 6.4.5.3
Version: 7.3
Expected: reject
Mutate: 18446744073709551616UL
Into: 18446744073709551615UL
Csc: CS1021
*/
class Program
{
    static void Main() { ulong outside = 18446744073709551616UL; }
}
