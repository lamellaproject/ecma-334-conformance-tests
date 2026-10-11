/*
Rules: E11-2-2-declaration-no-nullable-type
Authority: ECMA-334 7th ed 11.2.2
Version: 7.3
Expected: reject
Mutate: source is Optional value
Into: source is int value
*/
using Optional = System.Nullable<int>;
class Program
{
    static void Main()
    {
        object source = 29;
        if (source is Optional value) { }
    }
}
