using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KatController : MonoBehaviour
{
    public delegate int H();
    public H hu;
    private int ll;
    private int numbersOfNode;
    public int findNumber = 0;
    private GameObject activeTriger;

    private void OnTriggerEnter(Collider other)
    {
        if (activeTriger == null)
        {
            activeTriger = other.gameObject;
            Triger();
        }
    }
    private void Triger()
    {
        if (activeTriger?.layer == 6)
        {
            if (activeTriger.TryGetComponent(out ManagerOfNode node))
            {
                List<NodeOfKat> temp = node.NodeOfKats(this.gameObject, findNumber);
                if (temp.Count == 0)
                {
                    print("P");
                    activeTriger = null;
                    findNumber = 0;
                    hu = null;
                }
                else
                {
                    foreach (NodeOfKat kat in temp)
                    {
                        hu += kat.Updated;
                    }
                    numbersOfNode = temp.Count;
                }
            }
        }
    }

    private void FixedUpdate()
    {
        if (hu != null)
        {
            ll += hu.Invoke();
        }
        if (ll == numbersOfNode && ll != 0)
        {
            ll = 0;
            findNumber++;
            Triger();
        }
        // ShowNode();
    }


}


