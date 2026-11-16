/*
Rules: P10-file-namespace-block-exclusive
Authority: csc 5.12.0-1.26529.118 (C# 10.0)
Version: 10.0
Expected: reject
Mutate: namespace Annex { }
Into: class Annex { }
Csc: CS8955
*/
namespace Depot;
namespace Annex { }
class Program { static void Main() { } }
