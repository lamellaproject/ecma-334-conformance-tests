/*
Rules: E15-3-1-method-byref-only-overload
Authority: ECMA-334 7th ed 15.3.1
Version: 7.3
Expected: reject
Mutate: public void Read(out int value)
Into: public void Read(int value)
*/
class Meter
{
    public void Read(in int value) { }
    public void Read(out int value) { value = 223; }
}
class Program { static void Main() { } }
