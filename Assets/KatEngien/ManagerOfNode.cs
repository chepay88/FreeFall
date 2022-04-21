using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManagerOfNode : MonoBehaviour
{
    public NodeOfKat[] listik;
    List<GameObject> tempList = new List<GameObject>();
    // Start is called before the first frame update
    void Start()
    {
        listik = GetComponents<NodeOfKat>();
    }
    /// <summary>
    /// Ищим все нужные узлы
    /// </summary>
    /// <param name="object">Объект, к которому относятся узлы</param>
    /// <returns>Список узлов</returns>
    public List<NodeOfKat> NodeOfKats(GameObject @object, int number)
    {
        List<NodeOfKat> temp = new List<NodeOfKat>();
        foreach(NodeOfKat node in listik)
        {
            if (node.Object == @object)
            {
                if (node.NumberOfNodeInObject == number || node.NumberOfNodeInObject == -1)
                {
                    temp.Add(node);
                }
            }
        }
        return temp;
    }

}
