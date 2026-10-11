/*
Rules: E15-6-1-return-type-accessibility
Authority: ECMA-334 7th ed 15.6.1
Version: 7.3
Expected: reject
Mutate: public ref Hidden Cell()
Into: internal ref Hidden Cell()
Csc: CS0050
*/
class Hidden { }
public class Holder
{
    Hidden value;
    public ref Hidden Cell() { return ref value; }
}
class Program { static void Main() { } }
