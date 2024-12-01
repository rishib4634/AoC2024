// See https://aka.ms/new-console-template for more information
//Console.WriteLine("Hello, World!");
using System.Collections;

List<int> firstList = new();
List<int> secondList = new();

string filePath = "Input.txt";
int result = 0;

foreach (var line in File.ReadLines(filePath))
{
    var parts = line.Split(new char[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries);
    if (parts.Length == 2)
    {
        if (int.TryParse(parts[0], out int num1) && int.TryParse(parts[1], out int num2))
        {
            firstList.Add(num1);
            secondList.Add(num2);
        }
        else
        {
            Console.WriteLine("Invalid entry");
        }
    }
    else { Console.WriteLine("Invalid entry"); }
}

firstList.Sort(); 
secondList.Sort();
int lengthOfList = firstList.Count;
for(int i = 0; i < lengthOfList; i++)
{
    result += Math.Abs(firstList[i] - secondList[i]);
}

#region Part1
Console.WriteLine("Result is = {0} ", result);
Console.ReadLine();
#endregion

#region Part2
Dictionary<int, int> dict1 = new();
Dictionary<int, int> dict2 = new();
foreach (var item in firstList)
{
    if (dict1.ContainsKey(item))
    {
        dict1[item]++;
    }
    else
    {
        dict1[item] = 1;
    }
    
}

foreach (var item in secondList)
{
    if (dict2.ContainsKey(item))
    {
        dict2[item]++;
    }
    else
    {
        dict2[item] = 1;
    }
}

int resultNew = 0;

foreach (var item in dict1)
{
    if(dict2.ContainsKey(item.Key))
    {
        resultNew += item.Key * item.Value * dict2[item.Key] ;
    }
}

Console.WriteLine("Result for Part2 is = {0} ", resultNew);
Console.ReadLine();

#endregion


