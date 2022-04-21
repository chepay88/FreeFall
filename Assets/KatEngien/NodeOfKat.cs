using UnityEngine;
/// <summary>
/// Один узел в кат системе
/// </summary>
[System.Serializable]
public abstract class NodeOfKat : MonoBehaviour
{
    public int NumberOfNodeInObject;
    public GameObject Object;
    public abstract int Updated();
}



