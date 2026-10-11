/*
Rules: E15-3-1-event-name-unique; E15-3-1-method-nonmethod-name
Authority: ECMA-334 7th ed 15.3.1
Version: 7.3
Expected: reject
Mutate: public event Notice Mark;
Into: public event Notice Other;
*/
delegate void Notice();
class Meter
{
    public event Notice Mark;
    public void Mark() { }
}
class Program { static void Main() { } }
