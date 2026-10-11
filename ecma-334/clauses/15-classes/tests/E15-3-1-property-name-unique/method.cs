/*
Rules: E15-3-1-property-name-unique; E15-3-1-method-nonmethod-name
Authority: ECMA-334 7th ed 15.3.1
Version: 7.3
Expected: reject
Mutate: public int Mark { get { return 199; } }
Into: public int Other { get { return 199; } }
*/
class Meter
{
    public int Mark { get { return 199; } }
    public void Mark() { }
}
class Program { static void Main() { } }
