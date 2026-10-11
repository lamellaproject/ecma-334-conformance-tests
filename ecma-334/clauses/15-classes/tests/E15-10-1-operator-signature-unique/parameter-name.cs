/*
Rules: E15-10-1-operator-signature-unique
Authority: ECMA-334 7th ed 15.10.1
Version: 7.3
Expected: reject
Mutate: int operator +(Gauge renamed)
Into: int operator -(Gauge renamed)
Csc: CS0111
*/
class Gauge
{
    public static int operator +(Gauge x) { return 7; }
    public static int operator +(Gauge renamed) { return 9; }
}
class Program { static void Main() { } }
