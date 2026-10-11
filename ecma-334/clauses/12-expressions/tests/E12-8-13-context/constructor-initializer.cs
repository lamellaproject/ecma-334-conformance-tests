/*
Rules: E12-8-13-context
Authority: ECMA-334 7th ed 12.8.13
Version: 7.3
Expected: reject
Mutate: this(this.Seed, true)
Into: this(seed, true)
*/
class Box
{
    public int Seed;
    public Box(int seed) : this(this.Seed, true) { }
    Box(int seed, bool marker) { Seed = seed; }
}
class Program { static void Main() { new Box(8); } }
