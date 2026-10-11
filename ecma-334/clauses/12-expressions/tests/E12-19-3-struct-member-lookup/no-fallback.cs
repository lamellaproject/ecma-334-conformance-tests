/*
Rules: E12-19-3-struct-member-lookup; E12-19-3-no-struct-this
Authority: ECMA-334 7th ed 12.19.3
Version: 7.3
Expected: reject
Mutate: () => Value
Into: () => Owner.Value
*/
delegate int Result();
class Owner
{
    static int Value = 37;
    struct Cell
    {
        public int Value;
        public Result Make() { return () => Value; }
    }
}
class Program { static void Main() { } }
