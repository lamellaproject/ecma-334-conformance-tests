/*
Rules: E12-8-15-shared-implementation
Authority: ECMA-334 7th ed 12.8.15
Version: 7.3
Expected: reject
Mutate: public static Counter operator --(Counter value)
Into: public static Counter Alternate(Counter value)
*/
struct Counter
{
    public int Value;
    public Counter(int value) { Value = value; }
    public static Counter operator--(Counter value) { return new Counter(value.Value - 1); }
    public static Counter operator --(Counter value) { return new Counter(value.Value - 2); }
}
class Program { static void Main() { Counter value = new Counter(3); value--; --value; } }
