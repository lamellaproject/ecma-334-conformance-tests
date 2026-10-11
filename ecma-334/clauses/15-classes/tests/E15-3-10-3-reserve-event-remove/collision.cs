/*
Rules: E15-3-10-3-reserve-event-remove; E15-3-10-1-reserve-accessor-signatures; E15-3-10-1-reserved-signature-collision
Authority: ECMA-334 7th ed 15.3.10
Version: 7.3
Expected: reject
Mutate: public void remove_Changed(Signal handler)
Into: public void Unsubscribe(Signal handler)
*/
class Gauge
{
    public delegate void Signal();
    public event Signal Changed { add { } remove { } }
    public void remove_Changed(Signal handler) { }
}
class Program { static void Main() { } }
