/*
Rules: E15-3-1-constructor-ref-out-overload
Authority: ECMA-334 7th ed 15.3.1
Version: 7.3
Expected: reject
Mutate: public Meter(out int value)
Into: public Meter(out long value)
*/
class Meter
{
    public Meter(ref int value) { }
    public Meter(out int value) { value = 227; }
}
class Program { static void Main() { } }
