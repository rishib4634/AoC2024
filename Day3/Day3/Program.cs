// See https://aka.ms/new-console-template for more information
//Console.WriteLine("Hello, World!");

using System.Text.RegularExpressions;

string fileName = "Input.txt";

string inputLine = File.ReadAllText(fileName);

#region Part1
int result1 = CalculatePart1(inputLine);

Console.WriteLine(result1);
Console.ReadLine();

#endregion

#region Part2

int result2 = SplitAndCalculate(inputLine);
Console.WriteLine(result2);
Console.ReadLine();
#endregion

static int CalculatePart1(string inputLine)
{
    int result = 0;
    string pattern = @"mul\(\d{1,3},\d{1,3}\)";
    Regex regex = new Regex(pattern);
    MatchCollection matches = regex.Matches(inputLine);
    List<string> medStrings = regex.Matches(inputLine).OfType<Match>().Select(x => x.Value).ToList();
    //foreach (Match match in matches)
    //{
    //    medStrings.Add(match.Value);
    //} mul(1,2)
    medStrings.ForEach(x =>
    {
        var strLen = x.Length;
        var nStr = x.Substring(4, strLen - 5);
        var partition = nStr.Split(new char[] { ',' });
        _ = int.TryParse(partition[0], out int first );
        _ = int.TryParse(partition[1], out int second );
        result += first * second;
        //Console.WriteLine(nStr);
    
    });
    return result;
}

static int SplitAndCalculate(string inputLine)
{
    var splitsByDont = inputLine.Split(new string[] {"don't()"},StringSplitOptions.RemoveEmptyEntries);
    List<string> toConsider = new List<string>();
    toConsider.Add(splitsByDont[0]);
    for(int i = 1; i < splitsByDont.Length; i++)
    {
        var splitByDo = splitsByDont[i].Split("do()");
        if(splitByDo.Length >= 2)
        {
            for(int j = 1; j < splitByDo.Length; j++)
            {
                toConsider.Add(splitByDo[j]);
            }
        }
            
    }
    int result = 0;

    for (int i = 0; i < toConsider.Count; i++) {
        result += CalculatePart1(toConsider[i]);
    }

    
    return result;
}

