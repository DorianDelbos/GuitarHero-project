using UnityEngine;
using System.IO;

public class MapFileParser
{
    public static int[][] Parse(TextAsset textFile)
    {
        if (textFile == null)
        {
            Debug.LogError("Text file is not assigned.");
            return null;
        }

        string[] lines = textFile.text.Split('\n');
        int[][] result = new int[lines.Length][];

        for (int i = 0; i < lines.Length; i++)
        {
            string[] tokens = lines[i].Trim().Split(' ');
            result[i] = new int[tokens.Length];

            for (int j = 0; j < tokens.Length; j++)
            {
                if (int.TryParse(tokens[j], out int value))
                {
                    result[i][j] = value;
                }
                else
                {
                    Debug.LogError("Failed to parse an integer at line " + (i + 1) + ", column " + (j + 1));
                    return null;
                }
            }
        }

        return result;
    }
}