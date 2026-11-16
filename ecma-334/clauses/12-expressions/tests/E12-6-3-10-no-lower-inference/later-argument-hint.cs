/*
Rules: E12-6-3-10-no-lower-inference
Authority: ECMA-334 7th ed 12.6.3.10
Version: 7.3
Expected: run
Stdout: OK 3
Mutate: ReadArray(new ArrayParcel(seed + 2), seed)
Into: ReadArray(new ArrayParcel(seed + 2), "hint")
*/
using System;
interface Measure<T>
{
    T Read();
}
class Cell<T>
{
    public T Value;
    public Cell(T value) { Value = value; }
}
class ArrayParcel
{
    int value;
    public ArrayParcel(int value) { this.value = value; }
    public static implicit operator int[](ArrayParcel parcel)
    {
        return new int[] { parcel.value };
    }
}
class CellParcel
{
    int value;
    public CellParcel(int value) { this.value = value; }
    public static implicit operator Cell<int>(CellParcel parcel)
    {
        return new Cell<int>(parcel.value);
    }
}
class SplitParcel : Measure<int>, Measure<long>
{
    int value;
    public SplitParcel(int value) { this.value = value; }
    int Measure<int>.Read() { return value; }
    long Measure<long>.Read() { return -value; }
}
class Program
{
    static int cursor, checks, failures;
    static int Seed() { return ++cursor + 17; }
    static void Check(bool ok, string id)
    {
        checks++;
        if (!ok) { failures++; Console.WriteLine("FAIL " + id); }
    }
    static T ReadArray<T>(T[] values, T hint) { return values[0]; }
    static T ReadCell<T>(Cell<T> cell, T hint) { return cell.Value; }
    static T ReadMeasure<T>(Measure<T> measure, T hint) { return measure.Read(); }
    static void Main()
    {
        int seed = Seed();
        int array = ReadArray(new ArrayParcel(seed + 2), seed);
        Check(array == seed + 2, "array-hint");
        int cell = ReadCell(new CellParcel(seed + 4), seed);
        Check(cell == seed + 4, "constructed-hint");
        int measure = ReadMeasure(new SplitParcel(seed + 9), seed);
        Check(measure == seed + 9, "nonunique-interface-hint");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
