/*
Rules: E13-9-5-no-enumeration-binding-error
Authority: ECMA-334 7th ed 13.9.5
Version: 7.3
Expected: reject
Mutate: foreach (int item in new Source())
Into: foreach (int item in new int[0])
*/
class Program
{
    class Source { }
    static void Main() { foreach (int item in new Source()) { } }
}
