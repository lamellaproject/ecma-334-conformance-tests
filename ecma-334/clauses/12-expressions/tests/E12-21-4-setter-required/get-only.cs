/*
Rules: E12-21-4-setter-required
Authority: ECMA-334 7th ed 12.21.4
Version: 7.3
Expected: reject
Mutate: get { return 3; }
Into: get { return 3; } set { }
Csc: CS0200
*/
class Storage
{
    public int Value { get { return 3; } }
}
class Program
{
    static void Main() { var target = new Storage(); target.Value += 4; }
}
