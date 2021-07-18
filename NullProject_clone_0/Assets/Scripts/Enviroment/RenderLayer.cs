using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RenderLayer : MonoBehaviour
{
    private SpriteRenderer sprite;
    private GameObject[] player;
    // Start is called before the first frame update
    void Start()
    {
        sprite = this.GetComponent<SpriteRenderer>();
        player = GameObject.FindGameObjectsWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        for(int i = 0; i < player.Length; i++){
            if(player[i].transform.position.y < this.transform.position.y){
                sprite.sortingOrder = 1;
            }else{
                sprite.sortingOrder = 3;
            }
        }
    }
}
