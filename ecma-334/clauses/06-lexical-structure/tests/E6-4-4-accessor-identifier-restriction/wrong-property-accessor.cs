/*
Rules: E6-4-4-accessor-identifier-restriction
Authority: ECMA-334 7th ed 6.4.4
Version: 7.3
Expected: reject
Mutate: value { return 61; }
Into: get { return 61; }
*/
class Parcel
{
    public int Count { value { return 61; } }
}
class Program { static void Main() { } }
