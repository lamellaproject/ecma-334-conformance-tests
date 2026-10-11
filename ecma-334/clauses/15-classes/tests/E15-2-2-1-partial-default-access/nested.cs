/*
Rules: E15-2-2-1-partial-default-access
Authority: ECMA-334 7th ed 15.2.2.1
Version: 7.3
Expected: reject
Mutate: partial class Gauge { }
Into: public partial class Gauge { }
*/
public class Facade
{
    partial class Gauge { }
    partial class Gauge { int slot; }
    public Gauge Read() { return null; }
}
class Program { static void Main() { } }
