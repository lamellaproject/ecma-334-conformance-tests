/*
Rules: E12-19-3-no-struct-this
Authority: ECMA-334 7th ed 12.19.3
Version: 7.3
Expected: reject
Mutate: () => Value
Into: () => 31
*/
delegate int Result();
struct Cell
{
    public int Value;
    public Result Make() { return () => Value; }
}
class Program { static void Main() { } }
