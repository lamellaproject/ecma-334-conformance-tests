/*
Rules: E15-13-no-direct-finalize-call
Authority: ECMA-334 7th ed 15.13
Version: 7.3
Expected: reject
Mutate: base.Finalize();
Into: Release();
*/
class Gauge { public void Invoke() { base.Finalize(); } void Release() { } }
class Program { static void Main() { } }
