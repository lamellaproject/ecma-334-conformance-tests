/*
Rules: E15-13-no-direct-finalize-call; E15-13-finalizer-no-explicit-invocation
Authority: ECMA-334 7th ed 15.13
Version: 7.3
Expected: reject
Mutate: Finalize();
Into: Release();
*/
class Basis { ~Basis() { } }
class Gauge : Basis { ~Gauge() { } public void Invoke() { Finalize(); } void Release() { } }
class Program { static void Main() { } }
