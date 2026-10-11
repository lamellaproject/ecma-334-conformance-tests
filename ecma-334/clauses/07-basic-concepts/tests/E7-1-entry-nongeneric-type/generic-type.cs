/*
Rules: E7-1-entry-nongeneric-type
Authority: ECMA-334 7th ed 7.1
Version: 7.3
Expected: reject
Mutate: class Program<T>
Into: class Program
*/
class Program<T>
{
    static void Main() { }
}
