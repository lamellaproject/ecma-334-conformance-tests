/*
Rules: E6-2-5-ed5-unlisted-generic-following-token
Authority: ECMA-334 5th ed 7.2.5
Version: 5
Expected: reject
Version-Witness: version-witnesses/E6-2-5-ed5-unlisted-generic-following-token/before-relational.cs.part
Mutate: Flag<byte> < new Match()
Into: (Flag<byte>) < new Match()
*/
delegate bool Probe();
struct Match
{
    public static bool operator <(Probe probe, Match other) { return probe(); }
    public static bool operator >(Probe probe, Match other) { return !probe(); }
}
class Program
{
    static bool Flag<T>() { return true; }
    static bool Compare()
    {
        return Flag<byte> < new Match();
    }
    static void Main() { }
}
