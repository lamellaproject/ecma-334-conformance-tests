/*
Rules: E9-4-4-13-return-expression-entry
Authority: ECMA-334 7th ed 9.4.4.13
Version: 7.3
Expected: reject
Mutate: int cell;
Into: int cell = 18;
Csc: CS0165
*/
class Program
{
    static int Read() { int cell; return cell; }
    static void Main() { Read(); }
}
