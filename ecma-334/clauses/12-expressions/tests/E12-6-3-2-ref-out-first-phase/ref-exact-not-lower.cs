/*
Rules: E12-6-3-2-ref-out-first-phase; E12-6-3-9-exact-bound; E12-6-3-12-fixing-exact-filter
Authority: ECMA-334 7th ed 12.6.3.2
Version: 7.3
Expected: reject
Mutate: Next(ref value, 9L)
Into: Next(ref value, 9)
*/
class Program
{
    static void Next<T>(ref T location, T value) { location = value; }
    static void Main() { int value = 3; Next(ref value, 9L); }
}
