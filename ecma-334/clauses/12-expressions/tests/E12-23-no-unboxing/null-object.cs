/*
Rules: E12-23-no-unboxing
Authority: ECMA-334 7th ed 12.23
Version: 7.3
Expected: reject
Mutate: (int)(object)null
Into: (int)4
Csc: CS0133
*/
class Program
{
    const int Value = (int)(object)null;
    static void Main() { }
}
