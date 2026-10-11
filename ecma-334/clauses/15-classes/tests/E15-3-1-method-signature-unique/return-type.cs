/*
Rules: E15-3-1-method-signature-unique
Authority: ECMA-334 7th ed 15.3.1
Version: 7.3
Expected: reject
Mutate: public long Read(int second)
Into: public long Read(long second)
*/
class Meter
{
    public int Read(int first) { return first; }
    public long Read(int second) { return second; }
}
class Program { static void Main() { } }
