/*
Rules: E12-21-2-struct-access-variable-target
Authority: ECMA-334 7th ed 12.21.2
Version: 7.3
Expected: reject
Mutate: Make().Value = 4
Into: target.Value = 4
Csc: CS1612
*/
struct Storage
{
    int number;
    public int Value { get { return number; } set { number = value; } }
    public int this[int key] { set { number = value + key; } }
}
class Program
{
    static Storage Make() { return new Storage(); }
    static void Main() { var target = Make(); Make().Value = 4; target[0] = 5; }
}
