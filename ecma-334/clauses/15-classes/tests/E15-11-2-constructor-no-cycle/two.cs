/*
Rules: E15-11-2-constructor-no-cycle
Authority: ECMA-334 7th ed 15.11.2
Version: 7.3
Expected: reject
Mutate: public Gauge(int n) : this()
Into: public Gauge(int n) : base()
Csc: CS0768
*/
class Gauge { public Gauge() : this(13) { } public Gauge(int n) : this() { } }
class Program { static void Main() { } }
