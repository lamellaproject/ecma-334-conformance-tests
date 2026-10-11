/*
Rules: E12-23-reference-forms-only
Authority: ECMA-334 7th ed 12.23
Version: 7.3
Expected: reject
Mutate: const object Value = new object();
Into: const object Value = default(object);
Csc: CS0133
*/
class Program
{
    const object Value = new object();
    static void Main() { }
}
