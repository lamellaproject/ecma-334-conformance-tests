/*
Rules: E15-3-10-2-reserve-both-property-accessors; E15-3-10-2-reserve-property-get; E15-3-10-1-reserved-signature-collision
Authority: ECMA-334 7th ed 15.3.10
Version: 7.3
Expected: reject
Mutate: public int get_Code()
Into: public int Read()
*/
class Gauge
{
    public int Code { set { } }
    public int get_Code() { return 419; }
}
class Program { static void Main() { } }
