/*
Rules: E12-9-6-no-separate-implementation
Authority: ECMA-334 7th ed 12.9.6
Version: 7.3
Expected: reject
Mutate: operator ++(Counter alternate)
Into: operator --(Counter alternate)
*/
struct Counter
{
    public static Counter operator ++(Counter original) { return original; }
    public static Counter operator ++(Counter alternate) { return alternate; }
}
class Program { static void Main() { Counter c = new Counter(); ++c; c++; } }
