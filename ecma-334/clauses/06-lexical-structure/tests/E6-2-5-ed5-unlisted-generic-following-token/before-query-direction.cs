/*
Rules: E6-2-5-ed5-unlisted-generic-following-token
Authority: ECMA-334 5th ed 7.2.5
Version: 5
Expected: reject
Version-Witness: version-witnesses/E6-2-5-ed5-unlisted-generic-following-token/before-query-direction.cs.part
Mutate: Rank<short> ascending
Into: (Rank<short>) ascending
*/
delegate int Element();
delegate Element OrderKey(int position);
delegate int Projection(int position);
class Sequence
{
    public Sequence OrderBy(OrderKey key) { return this; }
    public int Select(Projection projection) { return projection(3); }
}
class Program
{
    static int Rank<T>() { return 11; }
    static int Query()
    {
        return from item in new Sequence() orderby Rank<short> ascending select item + 1;
    }
    static void Main() { }
}
