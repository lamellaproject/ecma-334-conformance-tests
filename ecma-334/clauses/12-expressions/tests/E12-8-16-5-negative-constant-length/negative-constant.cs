/*
Rules: E12-8-16-5-negative-constant-length
Authority: ECMA-334 7th ed 12.8.16.5
Version: 7.3
Expected: reject
Mutate: new byte[-2]
Into: new byte[2]
*/
class Program
{
    static void Main() { var cells = new byte[-2]; }
}
