using System.IO;
using UnityEngine;
public interface IFormatter 
{
    void Init();
    string Format(LogType type, string line);
    object Deserialize(Stream stream);
    void Serialize<T>(Stream stream, T source);
}
