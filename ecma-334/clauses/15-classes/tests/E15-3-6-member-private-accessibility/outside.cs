/*
Rules: E15-3-6-member-private-accessibility
Authority: ECMA-334 7th ed 15.3.6
Version: 7.3
Expected: reject
Mutate: private int Read() { return 463; }
Into: public int Read() { return 463; }
*/
class Vault { private int Read() { return 463; } }
class Program { static void Main() { new Vault().Read(); } }
