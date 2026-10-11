/*
Rules: E15-13-finalizer-no-explicit-invocation
Authority: ECMA-334 7th ed 15.13
Version: 7.3
Expected: reject
Mutate: this.~Gauge();
Into: this.Release();
*/
class Gauge { ~Gauge() { } void Release() { } public void Invoke() { this.~Gauge(); } }
class Program { static void Main() { } }
