/*
Rules: E15-6-9-partial-implicitly-private; E15-6-9-partial-invocation-containing-parts
Authority: ECMA-334 7th ed 15.6.9
Version: 7.3
Expected: reject
Mutate: new Gauge().Record();
Into: new Gauge().Invoke();
Csc: CS0122
*/
partial class Gauge
{
    partial void Record();
    partial void Record() { }
    public void Invoke() { Record(); }
}
class Program { static void Main() { new Gauge().Record(); } }
