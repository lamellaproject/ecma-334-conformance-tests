/*
Rules: E12-8-16-5-initializer-length-match
Authority: ECMA-334 7th ed 12.8.16.5
Version: 7.3
Expected: reject
Mutate: new int[1, 2] { { 7, 19, 23 } }
Into: new int[1, 3] { { 7, 19, 23 } }
*/
class Program
{
    static void Main() { var cells = new int[1, 2] { { 7, 19, 23 } }; }
}
