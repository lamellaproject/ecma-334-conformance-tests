/*
Rules: E16-4-1-no-finalizer
Authority: ECMA-334 7th ed 16.4.1
Version: 7.3
Expected: reject
Mutate: ~Entry() { }
Into: public void Dispose() { }
*/
struct Entry { ~Entry() { } }
class Program { static void Main() { } }
