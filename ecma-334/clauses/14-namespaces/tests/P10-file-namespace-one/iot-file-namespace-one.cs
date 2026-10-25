/*
Rules: P10-file-namespace-one
Authority: csc 5.11.0-1.26425.128 (C# 10.0)
Version: 10.0
Expected: reject
Mutate: namespace Quay; namespace Dock;
Into: namespace Quay;
Csc: CS8954
*/
namespace Quay; namespace Dock;
class Program { static void Main() { } }
