namespace OrederLIst;

class Program
{
    public static void Main()
    {
        var test = new OrderedList<int>();
        var test2 = new OrderedList<int>();
        
        var testingArray = new [] { 25, 150, 321, 5, 3, 234, 54, 234, 654, 76, 34, 7, 987, 564, 234, };
        var testingArrayForMerge = new [] { 4, 6, 8, 26, 988 };
        
        foreach (var number in testingArray)
        {
            test.Add(number);
        }

        foreach (var number in testingArrayForMerge)
        {
            test2.Add(number);
        }

        Console.WriteLine(test);
        Console.WriteLine("------------------");
       
        test.Merge(test2);
        Console.WriteLine(test2);
       
    }
}