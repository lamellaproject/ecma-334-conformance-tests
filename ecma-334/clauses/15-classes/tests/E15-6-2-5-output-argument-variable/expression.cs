/*
Rules: E15-6-2-5-output-argument-variable
Authority: ECMA-334 7th ed 15.6.2.5
Version: 7.3
Expected: reject
Mutate: Write(out Make())
Into: Write(out value)
Csc: CS1510
*/
class Program
{
    static int Make() { return 31; }
    static void Write(out int value) { value = 31; }
    static void Main() { int value; Write(out Make()); }
}
