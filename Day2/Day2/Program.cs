// See https://aka.ms/new-console-template for more information
//Console.WriteLine("Hello, World!");

string inputFile = "Input.txt";
List<List<int>> myList = new();



foreach (var line in File.ReadLines(inputFile))
{
    var cols = line.Split(new char[] { ' ','\t'},StringSplitOptions.RemoveEmptyEntries);
    List<int> temp = new List<int>();
    if(cols.Length > 0 )
    {
        for(int i = 0; i < cols.Length; i++)
        {
            if (int.TryParse(cols[i], out int val))
            {
                temp.Add(val);
            }
        }
    }
    myList.Add(temp);
}


#region Part1
int result = 0;
int track;

foreach (var midList in myList)
{
    if (IsOk(midList))
    {
        result++;
    }
    

}
Console.WriteLine("Result for Part1 is = {0}", result);
Console.ReadLine();

#endregion

#region Part2

int result1 = 0;
//int track1, track2, track3, track4;

foreach (var midList in myList)
{
    if (IsOk(midList))
    {
        result1++;
    }
    else
    {
        for (int i = 0; i < midList.Count-1; i++)
        {
            List<int> newMidList = midList;
            newMidList.RemoveAt(i);
            if (IsOk(newMidList))
            {
                result1++;
                break;
            }

        }
    }

}
Console.WriteLine("Result for Part2 is = {0}", result1);
Console.ReadLine();

#endregion

static bool IsOk(List<int> midList)
{
    var midArr = midList.ToArray();
    int inc = midArr[0] < midArr[1] ? 1 : 0;
    bool result = true;
    for (int i = 0; i < midArr.Length - 1; i++)
    {
        if ((inc == 1) && (midArr[i + 1] - midArr[i] >= 1) && (midArr[i + 1] - midArr[i] <= 3))
        {
            continue;
        }

        else if ((inc == 0) && (midArr[i] - midArr[i + 1] >= 1) && (midArr[i] - midArr[i + 1] <= 3))
        {
            continue;
        }
        else
        {
            result = false;
        }
    }
    
    return result;
}
