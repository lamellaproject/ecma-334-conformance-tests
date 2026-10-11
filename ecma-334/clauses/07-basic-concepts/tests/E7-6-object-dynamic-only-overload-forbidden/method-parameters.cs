/*
Rules: E7-6-object-dynamic-only-overload-forbidden; E7-6-object-dynamic-signature-equality
Authority: ECMA-334 7th ed 7.6
Version: 7.3
Expected: reject
Mutate: Read(dynamic value)
Into: Read(string value)
*/
class Program
{
    static int Read(object value) { return 113; }
    static int Read(dynamic value) { return 127; }
    static void Main() { }
}
