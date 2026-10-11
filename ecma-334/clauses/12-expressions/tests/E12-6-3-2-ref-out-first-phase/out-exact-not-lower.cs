/*
Rules: E12-6-3-2-ref-out-first-phase; E12-6-3-12-fixing-exact-filter
Authority: ECMA-334 7th ed 12.6.3.2
Version: 7.3
Expected: reject
Mutate: Copy(7L, out value)
Into: Copy(7, out value)
*/
class Program
{
    static void Copy<T>(T source, out T destination) { destination = source; }
    static void Main() { int value; Copy(7L, out value); }
}
