/*
Rules: E15-6-1-method-attributes; E15-6-1-grammar-method-declaration-form-2
Authority: ECMA-334 7th ed 15.6.1
Version: 7.3
Expected: reject
Mutate: [System.Obsolete("ref-method-marker", true)]
Into: 
Csc: CS0619
*/
class Holder
{
    int value;
    [System.Obsolete("ref-method-marker", true)]
    public ref int Cell() { return ref value; }
}
class Program { static void Main() { ref int alias = ref new Holder().Cell(); } }
