/*
Rules: E15-6-1-ordinary-ref-body
Authority: ECMA-334 7th ed 15.6.1
Version: 7.3
Expected: reject
Mutate: public ref int Cell();
Into: public ref int Cell() { return ref value; }
Csc: CS0501
*/
class Holder
{
    int value;
    public ref int Cell();
}
class Program { static void Main() { } }
