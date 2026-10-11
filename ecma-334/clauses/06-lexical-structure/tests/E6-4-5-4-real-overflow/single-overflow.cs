/*
Rules: E6-4-5-4-real-overflow
Authority: ECMA-334 7th ed 6.4.5.4
Version: 7.3
Expected: reject
Mutate: 4e38F
Into: 4e37F
Csc: CS0594
*/
class Program
{
    static void Main() { float outside = 4e38F; }
}
