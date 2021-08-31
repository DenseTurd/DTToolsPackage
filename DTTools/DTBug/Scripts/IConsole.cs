using UnityEngine;
public interface IConsole 
{
    void Init();
    void AddLine(LogType type, string line);
}
