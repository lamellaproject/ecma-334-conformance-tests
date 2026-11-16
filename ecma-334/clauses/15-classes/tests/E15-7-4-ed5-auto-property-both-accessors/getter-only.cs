/*
Rules: E15-7-4-ed5-auto-property-both-accessors
Authority: ECMA-334 5th ed 15.7.4
Version: 5
Expected: reject
Version-Witness: tests/E15-7-4-ed5-auto-property-both-accessors/paired-accessors.cs.part
Mutate: int Reading { get; }
Into: int Reading { get; set; }
*/
class Sensor
{
    public int Reading { get; }
}
class Program
{
    static void Main() { }
}
