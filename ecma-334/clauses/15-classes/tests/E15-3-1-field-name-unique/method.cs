/*
Rules: E15-3-1-field-name-unique; E15-3-1-method-nonmethod-name
Authority: ECMA-334 7th ed 15.3.1
Version: 7.3
Expected: reject
Mutate: public int Mark;
Into: public int Other;
*/
class Meter
{
    public int Mark;
    public void Mark() { }
}
class Program { static void Main() { } }
