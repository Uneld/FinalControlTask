const int MAX_SIZE_INPUT_ARRAY = 10;
const int MAX_SIZE_STRING = 3;

void PrintArrayString(string[] array)
{
    System.Console.WriteLine($"[{string.Join(", ", array)}]");
}

string[] SingleLineInput(int maxSizeArray)
{
    string[] array;
    System.Console.WriteLine("Enter string array with a \"space\"");
    do
    {
        array = Console.ReadLine().Split(" ");
        if (array.Length > maxSizeArray)
        {
            System.Console.WriteLine("Wrong enter, please try again");
        }
    } while (array.Length > maxSizeArray);
    return array;
}

string[] ReleaseArray1(string[] array)
{
    return array.Where(x => x.Length <= MAX_SIZE_STRING).ToArray(); ;
}


string[] ReleaseArray2(string[] array)
{
    string[] outputArray = new string[array.Length];
    int outputIterator = 0;
    for (int i = 0; i < array.Length; i++)
    {
        if (array[i].Length <= MAX_SIZE_STRING)
        {
            outputArray[outputIterator] = array[i];
            outputIterator++;
        }
    }
    Array.Resize(ref outputArray, outputIterator);
    return outputArray;
}

System.Console.Clear();
System.Console.WriteLine("Please enter array");
string[] inputArray = SingleLineInput(MAX_SIZE_INPUT_ARRAY);
PrintArrayString(inputArray);

string[] releaseArray;

System.Console.WriteLine("Way 1");
releaseArray = ReleaseArray1(inputArray);
PrintArrayString(releaseArray);

System.Console.WriteLine("Way 2");
releaseArray = ReleaseArray2(inputArray);
PrintArrayString(releaseArray);