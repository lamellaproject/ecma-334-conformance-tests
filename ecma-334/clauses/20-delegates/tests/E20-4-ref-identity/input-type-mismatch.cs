/*
Rules: E20-4-ref-identity
Authority: ECMA-334 7th ed 20.4
Version: 7.3
Expected: reject
Mutate: delegate void Read(in string value);
Into: delegate void Read(in object value);
Csc: CS0123
*/
delegate void Read(in string value);
class Program
{
    static void Touch(in object value) { }
    static void Main() { Read read = Touch; }
}
