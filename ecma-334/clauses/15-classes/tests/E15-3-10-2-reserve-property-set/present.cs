/*
Rules: E15-3-10-2-reserve-property-set; E15-3-10-1-reserve-accessor-signatures; E15-3-10-1-reserved-signature-collision
Authority: ECMA-334 7th ed 15.3.10
Version: 7.3
Expected: reject
Mutate: public void set_Code(int value)
Into: public void Write(int value)
*/
class Gauge
{
    public int Code { set { } }
    public void set_Code(int value) { }
}
class Program { static void Main() { } }
