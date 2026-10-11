/*
Rules: E9-7-2-3-struct-this-context
Authority: ECMA-334 7th ed 9.7.2.3
Version: 7.3
Expected: reject
Mutate: return ref this;
Into: return ref backup;
Csc: CS8170
*/
struct Cell
{
    static Cell backup;
    public ref Cell Select()
    {
        return ref this;
    }
}
class Program { static void Main() { } }
