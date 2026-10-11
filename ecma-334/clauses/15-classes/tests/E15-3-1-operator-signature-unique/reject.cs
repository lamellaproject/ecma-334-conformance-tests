/*
Rules: E15-3-1-operator-signature-unique
Authority: ECMA-334 7th ed 15.3.1
Version: 7.3
Expected: reject
Mutate: public static Meter operator -(Meter second)
Into: public static Meter operator +(Meter second)
*/
class Meter
{
    public static Meter operator -(Meter first) { return first; }
    public static Meter operator -(Meter second) { return second; }
}
class Program { static void Main() { } }
