/*
Rules: E15-3-1-constructor-signature-unique
Authority: ECMA-334 7th ed 15.3.1
Version: 7.3
Expected: reject
Mutate: public Meter(int second)
Into: public Meter(long second)
*/
class Meter
{
    public Meter(int first) { }
    public Meter(int second) { }
}
class Program { static void Main() { } }
