/*
Rules: E15-6-1-extern-ref-semicolon
Authority: ECMA-334 7th ed 15.6.1
Version: 7.3
Expected: reject
Mutate: public extern ref int Cell() => ref value;
Into: public extern ref int Cell();
Csc: CS0179
*/
class Holder
{
    int value;
    public extern ref int Cell() => ref value;
}
class Program { static void Main() { } }
