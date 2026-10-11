/*
Rules: E15-3-6-default-private
Authority: ECMA-334 7th ed 15.3.6
Version: 7.3
Expected: reject
Mutate: int Read() { return 467; }
Into: public int Read() { return 467; }
*/
class Vault { int Read() { return 467; } }
class Program { static void Main() { new Vault().Read(); } }
