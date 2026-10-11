/*
Rules: E12-21-4-invalid-compound
Authority: ECMA-334 7th ed 12.21.4
Version: 7.3
Expected: reject
Mutate: public static explicit operator Number
Into: public static implicit operator Number
Csc: CS0266
*/
struct Number
{
    public static Wider operator +(Number left, int right) { return new Wider(); }
    public static explicit operator Number(Wider value) { return new Number(); }
}
struct Wider { }
class Program
{
    static void Main() { Number value = new Number(); value += 4; }
}
