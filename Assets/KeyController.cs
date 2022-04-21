using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyController : MonoBehaviour
{
    public List<KeyPropertyes> Keys = new List<KeyPropertyes>();
    public KeyCode GetKey(NameOfComand value)
    {
        foreach (KeyPropertyes key in Keys)
        {
            if (key.Comand == value)
            {
                return key.Key;
            }
        }
        return KeyCode.Alpha8;
    }
}

[System.Serializable]
public struct KeyPropertyes
{
    public KeyCode Key;
    public NameOfComand Comand;
}

public enum NameOfComand
{
    Up,
    Down,
    Left,
    Right

}
