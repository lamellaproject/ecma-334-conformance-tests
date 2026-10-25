/*
Rules: P10-struct-constructor-create; E16-4-9-this-assigned-on-return
Authority: csc 5.11.0-1.26425.128 (C# 10.0)
Version: 10.0
Expected: reject
Mutate: public Pair() { first = 83; }
Into: public Pair() { first = 83; second = 89; }
*/
// At C#10 the explicit constructor must assign both fields (proposal L76).
// The later auto-default struct feature is outside this constructor batch.
readonly record struct Pair
{
    readonly int first, second;
    public Pair() { first = 83; }
}
class Program { static void Main() { } }
