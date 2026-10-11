/*
Rules: E12-21-4-getter-required
Authority: ECMA-334 7th ed 12.21.4
Version: 7.3
Expected: reject
Mutate: public int Value { set
Into: public int Value { get { return number; } set
Csc: CS0154
*/
class Storage
{
    int number;
    public int Value { set { number = value; } }
}
class Program
{
    static void Main() { var target = new Storage(); target.Value += 4; }
}
