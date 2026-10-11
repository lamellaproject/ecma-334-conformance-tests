/*
Rules: E6-4-5-4-real-overflow
Authority: ECMA-334 7th ed 6.4.5.4
Version: 7.3
Expected: reject
Mutate: 1e29M
Into: 1e28M
Csc: CS0594
*/
class Program
{
    static void Main() { decimal outside = 1e29M; }
}
