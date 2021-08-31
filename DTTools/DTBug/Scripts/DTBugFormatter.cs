using UnityEngine;
using System.Collections.Generic;
using System;
using System.IO;

public class DTBugFormatter : MonoBehaviour,IFormatter
{
    public bool showTime = true;

    [SerializeField]
    public Color logColor;
    public Color warningColor;
    public Color errorColor;
    public Color assertColor;
    public Color exceptionColor;

    Dictionary<LogType, Color> typeColorDict;

    public void Init()
    {
        typeColorDict = new Dictionary<LogType, Color>()
        {
            { LogType.Log, logColor },
            { LogType.Warning, warningColor },
            { LogType.Error, errorColor },
            { LogType.Assert, assertColor },
            { LogType.Exception, exceptionColor }
        };

        //Debug.Log("DTBug formatter initialised");
    }

    public string Format(LogType type, string line)
    {
        string formattedString;
        Color color = typeColorDict[type];
        formattedString = Prefix(line);
        formattedString = "<color=#" + ColorUtility.ToHtmlStringRGBA(color) + ">" + formattedString + "</color>";
        return formattedString;
    }

    string Prefix(string line)
    {
        string prefixedString = "";
        if (showTime)
        {
            prefixedString = DateTime.Now.ToLongTimeString() + " ";
        }
        prefixedString += line;
        return prefixedString;
    }

    public object Deserialize(Stream stream)
    {
        throw new NotImplementedException();
    }

    public void Serialize<T>(Stream stream, T source)
    {
        throw new NotImplementedException();
    }
}
