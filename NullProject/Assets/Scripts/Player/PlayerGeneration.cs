using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGeneration : MonoBehaviour
{
    public GameObject playerObj;
    int tileToGenerateX;
    int tileToGenerateY;
    // Start is called before the first frame update
    void Start()
    {
        tileToGenerateX = Random.Range(1, 200); //what x tile to be generated on
        tileToGenerateY = Random.Range(1, 200); //what y tile to be generated on
        GameObject player = Instantiate(playerObj, new Vector3(tileToGenerateX, tileToGenerateY, 0), Quaternion.identity); //generate the player on that tile
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
