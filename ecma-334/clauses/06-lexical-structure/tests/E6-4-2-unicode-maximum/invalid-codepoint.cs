/*
Rules: E6-4-2-unicode-maximum
Authority: ECMA-334 7th ed 6.4.2
Version: 7.3
Expected: reject
Mutate: "\U00110000"
Into: "\U0010FFFF"
Csc: CS1009
*/
class Program
{
    static void Main() { string outside = "\U00110000"; }
}
