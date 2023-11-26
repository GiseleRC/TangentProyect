using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;

public class LanguageSplit
{
    public static Dictionary<Language, Dictionary<string, string>> LoadCodexFromString(string source, string sheet)
    {
        var codex = new Dictionary<Language, Dictionary<string, string>>();
        var idxToLang = new Dictionary<int, Language>();

        int lineNum = 0;
        using (StringReader reader = new StringReader(sheet))
        {
            string line;
            while ((line = reader.ReadLine()) != null)
            {
                ++lineNum;
                line = line.Trim();

                if (string.IsNullOrEmpty(line))
                    continue;

                string[] cells = line.Split('\t');

                if (lineNum == 1)
                {

                    for (int i = 1; i < cells.Length; ++i)
                    {
                        Language language;
                        if (Enum.TryParse(cells[i], out language))
                        {
                            idxToLang[i] = language;
                            codex[language] = new Dictionary<string, string>();
                        }
                        else
                        {
                            Debug.Log($"Parsing CSV file {source}, at line {lineNum}, invalid language {cells[i]}");
                        }
                    }
                    continue;
                }

                for (int i = 1; i < cells.Length; ++i)
                {
                    codex[idxToLang[i]][cells[0]] = cells[i];
                }
            }
        }

        return codex;
    }
}
