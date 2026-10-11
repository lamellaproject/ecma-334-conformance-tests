/*
Rules: E20-4-ref-identity
Authority: ECMA-334 7th ed 20.4
Version: 7.3
Expected: reject
Mutate: delegate void Read(out object value);
Into: delegate void Read(out string value);
Csc: CS0123
*/
delegate void Read(out object value);
class Program
{
    static void Touch(out string value) { value = "yew"; }
    static void Main() { Read read = Touch; }
}
