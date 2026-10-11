/*
Rules: E15-6-1-abstract-ref-semicolon
Authority: ECMA-334 7th ed 15.6.1
Version: 7.3
Expected: reject
Mutate: public abstract ref int Cell() { return ref value; }
Into: public abstract ref int Cell();
Csc: CS0500
*/
abstract class Holder
{
    int value;
    public abstract ref int Cell() { return ref value; }
}
class Program { static void Main() { } }
