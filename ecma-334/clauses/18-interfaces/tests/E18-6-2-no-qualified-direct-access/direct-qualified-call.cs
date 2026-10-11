/*
Rules: E18-6-2-no-qualified-direct-access
Authority: ECMA-334 7th ed 18.6.2
Version: 7.3
Expected: reject
Mutate: reader.IRead.Read()
Into: ((IRead)reader).Read()
Csc: CS1061
*/
interface IRead { int Read(); }
class Reader : IRead { int IRead.Read() { return 191; } }
class Program { static void Main() { Reader reader = new Reader(); reader.IRead.Read(); } }
