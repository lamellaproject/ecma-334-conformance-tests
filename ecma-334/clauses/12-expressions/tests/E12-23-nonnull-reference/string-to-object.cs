/*
Rules: E12-23-nonnull-reference
Authority: ECMA-334 7th ed 12.23
Version: 7.3
Expected: reject
Mutate: (object)"token"
Into: (object)(string)null
Csc: CS0134
*/
class Program
{
    const object Value = (object)"token";
    static void Main() { }
}
