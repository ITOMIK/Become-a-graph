using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Ground : MonoBehaviour
{
    public GameObject tile;
    public int max_count_of_blocks = 15;
    List<GameObject> blocks;
    private Vector2 pos_block;
    System.Random rnd = new System.Random();
    public int near_bound = 5;
    public int far_bound =10;
    public float v_bound = 11;
    public Transform player;

     private void Start()
     {
        pos_block = new Vector2(0f,0f);
        blocks = new List<GameObject>();
        //Debug.Log(String.Format("{0}",tile));
        //var new_tile = Instantiate(tile,pos_block, Quaternion.identity);
    }
    private bool checkblock(Vector2 p)
    {
        for(int i=0; i<blocks.Count; i++)
        {
            var t = blocks[i].GetComponentInChildren<Transform>();
            if(Vector2.Distance(p,t.position)<1.5)
                return false;
            
        }
        return true;
    }

    private void generateblocks()
    {
        if(blocks.Count<=max_count_of_blocks)
        {
            int cnt=0;
            do
            {   
                int x=1;
                int y=1;
                //if(rnd.Next(2)<1)
                    //x=-1;
                if(rnd.Next(2)<1)
                    y=-1;
                pos_block.x = player.position.x + rnd.Next(near_bound, far_bound)*x;
                pos_block.y = player.position.y + rnd.Next(near_bound, far_bound)*y;
                cnt++;
                if(cnt>100)
                    return;
            }while(!checkblock(pos_block));
            
            var new_tile = Instantiate(tile,pos_block, Quaternion.identity);
            blocks.Add(new_tile);
        }   
         
    }

    private void clearblocks()
    {
        for(int i=0;i< blocks.Count; i++)
            {
                var t = blocks[i].GetComponentInChildren<Transform>();
                if(Vector2.Distance(t.position, player.position)>v_bound)//t._onScreen==false)
                {
                    Destroy(blocks[i]);
                    blocks.RemoveAt(i);
                }
            }
    }

    void FixedUpdate()
    {
        Debug.Log(String.Format("{0}",blocks.Count));

        generateblocks();

        clearblocks();
    }

        
}
