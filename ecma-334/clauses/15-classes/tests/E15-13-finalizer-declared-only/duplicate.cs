/*
Rules: E15-13-finalizer-declared-only
Authority: ECMA-334 7th ed 15.13
Version: 7.3
Expected: reject
Mutate: ~Gauge() => Release();
Into: void ReleaseAgain() => Release();
*/
class Gauge { ~Gauge() { } ~Gauge() => Release(); void Release() { } }
class Program { static void Main() { } }
