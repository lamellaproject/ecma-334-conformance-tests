/*
Rules: E15-3-7-constituent-accessibility
Authority: ECMA-334 7th ed 15.3.7
Version: 7.3
Expected: reject
Mutate: private delegate void Signal();
Into: public delegate void Signal();
*/
public class Packet
{
    private delegate void Signal();
    public event Signal Changed { add { } remove { } }
}
class Program { static void Main() { } }
