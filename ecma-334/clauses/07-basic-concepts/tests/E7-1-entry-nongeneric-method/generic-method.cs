/*
Rules: E7-1-entry-nongeneric-method
Authority: ECMA-334 7th ed 7.1
Version: 7.3
Expected: reject
Mutate: static void Main<T>()
Into: static void Main()
*/
class Program
{
    static void Main<T>() { }
}
