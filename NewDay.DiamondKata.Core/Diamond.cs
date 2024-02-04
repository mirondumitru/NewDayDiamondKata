using System.Text;

namespace NewDay.DiamondKata.Core;

public class Diamond
{
    private readonly char[] _perimeter;
    private readonly char _blankChar;

    public Diamond(char[] perimeter, char blankChar)
    {
        _perimeter = perimeter;
        _blankChar = blankChar;
    }

    public override string ToString()
    {
       var sb = new StringBuilder();

       var matrix = CreateMatrix();

       for (var i = 0; i < matrix.Length; i++)
       {
           var line = matrix[i];
           sb.Append(new string(line));

           if (i < matrix.Length - 1) 
               sb.AppendLine();
       }

       return sb.ToString();
    }

    private char[][] CreateMatrix()
    {
        var size = _perimeter.Length * 2 - 1;
        var matrix = new char[size][];
        var middle = size / 2;

        for (var i = 0; i < size; i++)
        {
            var line = new char[size];
            Array.Fill(line, _blankChar);

            if (i <= middle)
            {
                line[middle - i] = _perimeter[i];
                line[middle + i] = _perimeter[i];
            }
            else
            {
                line[i - middle] = _perimeter[size - 1 - i];
                line[size - 1 - (i - middle)] = _perimeter[size - 1 - i];
            }

            matrix[i] = line;
        }

        return matrix;
    }
}