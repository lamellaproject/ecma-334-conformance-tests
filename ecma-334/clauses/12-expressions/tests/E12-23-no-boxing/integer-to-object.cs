/*
Rules: E12-23-no-boxing
Authority: ECMA-334 7th ed 12.23
Version: 7.3
Expected: reject
Mutate: (object)7
Into: (object)null
Csc: CS0134
*/
class Program
{
    const object Value = (object)7;
    static void Main() { }
}
