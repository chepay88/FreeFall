using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NodeOfTranslate : NodeOfKat
{
    public Transform target;
    PlayerController player;
    int temp = 0;
    private void Start()
    {
        player = Object.GetComponent<PlayerController>();
    }
    public override int Updated()
    {
        Vector3 direction = target.position - player.trans.position;
        player.trans.position += direction.normalized * Time.deltaTime * player.Speed;
        if (direction.x < 0.01f && direction.y < 0.01f && direction.z < 0.01f)
        {
            print(0);
            temp = 1;
            player.OnActivatorComponent(true);
           // player.
        }
        return temp;
    }

}
