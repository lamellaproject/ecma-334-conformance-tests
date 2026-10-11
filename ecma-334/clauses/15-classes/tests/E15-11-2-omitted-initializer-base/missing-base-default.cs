/*
Rules: E15-11-2-omitted-initializer-base
Authority: ECMA-334 7th ed 15.11.2
Version: 7.3
Expected: reject
Mutate: public Gauge() {
Into: public Gauge() : base(13) {
Csc: CS7036
*/
class Basis { public Basis(int n) { } }
class Gauge : Basis { public Gauge() { } }
class Program { static void Main() { } }
