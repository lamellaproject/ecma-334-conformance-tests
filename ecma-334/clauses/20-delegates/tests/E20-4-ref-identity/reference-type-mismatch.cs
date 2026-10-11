/*
Rules: E20-4-ref-identity
Authority: ECMA-334 7th ed 20.4
Version: 7.3
Expected: reject
Mutate: delegate void Edit(ref string value);
Into: delegate void Edit(ref object value);
Csc: CS0123
*/
delegate void Edit(ref string value);
class Program
{
    static void Touch(ref object value) { }
    static void Main() { Edit edit = Touch; }
}
