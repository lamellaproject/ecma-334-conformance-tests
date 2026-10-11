/*
Rules: E12-8-1-pointer-member-unsafe
Authority: ECMA-334 7th ed 12.8.1
Version: 7.3
Expected: reject
Mutate: static void Main()
Into: static unsafe void Main()
Csc: CS0214
*/
struct Cell { public int value; }
unsafe class Owner { public static Cell* pointer; }
class Program
{
    static void Main()
    {
        int result = Owner.pointer->value;
    }
}
