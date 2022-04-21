using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NodeOfRotationKat : NodeOfKat
{
    public Transform target;
    int f = 0;
    Quaternion temp;
    PlayerController player;

    private void Start()
    {
        player = Object.GetComponent<PlayerController>();
    }
    public override int Updated()
    {
        
        if (f == 0)
        {
            Vector3 direction = target.position - player.trans.position;
            player.OnActivatorComponent(false);
            Vector3 r = Vector3.RotateTowards(player.trans.forward, direction, 1 * Time.deltaTime, 0) ;
            player.trans.rotation = Quaternion.LookRotation(r);
            if (player.trans.rotation == temp) f = 1;
            temp = player.trans.rotation;
        }
        return f;
    }


}
