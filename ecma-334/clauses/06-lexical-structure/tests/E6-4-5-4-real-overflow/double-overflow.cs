/*
Rules: E6-4-5-4-real-overflow
Authority: ECMA-334 7th ed 6.4.5.4
Version: 7.3
Expected: reject
Mutate: 2e309D
Into: 1e308D
Csc: CS0594
*/
class Program
{
    static void Main() { double outside = 2e309D; }
}
