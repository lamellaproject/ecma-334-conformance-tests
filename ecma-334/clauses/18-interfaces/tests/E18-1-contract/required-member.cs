/*
Rules: E18-1-contract; E18-6-5-all-members
Authority: ECMA-334 7th ed 18.1
Version: 7.3
Expected: reject
Mutate: class Worker : IWork { }
Into: class Worker : IWork { public int Work() { return 17; } }
Csc: CS0535
*/
interface IWork { int Work(); }
class Worker : IWork { }
class Program { static void Main() { IWork worker = new Worker(); worker.Work(); } }
