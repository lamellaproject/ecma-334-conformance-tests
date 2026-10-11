/*
Rules: E7-1-entry-nongeneric-enclosing-types
Authority: ECMA-334 7th ed 7.1
Version: 7.3
Expected: reject
Mutate: class Envelope<T>
Into: class Envelope
*/
class Envelope<T>
{
    class Program
    {
        static void Main() { }
    }
}
