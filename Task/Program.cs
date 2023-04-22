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


string[] ReleaseArray3(string[] array)
{
    int outputIterator = 0;

    for (int i = 0; i < array.Length; i++)
    {
        if (array[i].Length <= MAX_SIZE_STRING)
        {
            outputIterator++;
        }
    }
    string[] outputArray = new string[outputIterator];
    outputIterator = 0;
    for (int i = 0; i < array.Length; i++)
    {
        if (array[i].Length <= MAX_SIZE_STRING)
        {

            outputArray[outputIterator] = array[i];
            outputIterator++;
        }
    }
    return outputArray;
}


string[] ReleaseArray4(ref string[] array, int length)
{
    //если дошли до длинны 1 проверяем последний кусок массива
    if (length == 1)
    {
        // если подошло возврат текущего
        if (array[length - 1].Length <= MAX_SIZE_STRING)
        {
            return new string[] { array[length - 1] };
        }
        // возврат пустого
        return new string[0];
    }

    // забираем то что вернула функция для lenght - 1
    string[] tempArray = ReleaseArray4(ref array, length - 1);

    /*
        проверяем если текущий элемент подходит под условие 
        то копируем в новый массив предыдущий возврат и добавляем текущий элемент в конец 
    */
    if (array[length - 1].Length <= MAX_SIZE_STRING)
    {
        string[] outputArray = new string[tempArray.Length + 1];
        for (int i = 0; i < tempArray.Length; i++)
        {
            outputArray[i] = tempArray[i];
        }
        outputArray[tempArray.Length] = array[length - 1];
        return outputArray;
    }
    //если не подошло просто вовращаем предыдущий массив
    return tempArray;
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

System.Console.WriteLine("Way 3");
releaseArray = ReleaseArray3(inputArray);
PrintArrayString(releaseArray);

System.Console.WriteLine("Way 4");
releaseArray = ReleaseArray4(ref inputArray, inputArray.Length);
PrintArrayString(releaseArray);