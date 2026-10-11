/*
Rules: E15-6-1-method-attributes
Authority: ECMA-334 7th ed 15.6.1
Version: 7.3
Expected: reject
Mutate: [System.Obsolete("method-marker", true)]
Into: 
Csc: CS0619
*/
class Holder
{
    [System.Obsolete("method-marker", true)]
    public int Read() { return 3; }
}
class Program { static void Main() { new Holder().Read(); } }
