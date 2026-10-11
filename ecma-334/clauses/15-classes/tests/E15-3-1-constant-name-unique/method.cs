/*
Rules: E15-3-1-constant-name-unique; E15-3-1-method-nonmethod-name
Authority: ECMA-334 7th ed 15.3.1
Version: 7.3
Expected: reject
Mutate: public const int Mark = 197;
Into: public const int Other = 197;
*/
class Meter
{
    public const int Mark = 197;
    public void Mark() { }
}
class Program { static void Main() { } }
