/*
Rules: E6-4-6-right-shift-adjacency
Authority: ECMA-334 7th ed 6.4.6
Version: 7.3
Expected: reject
Mutate: > >
Into: >>
*/
class Program
{
    static void Main() { int value = 96 > > 3; }
}
