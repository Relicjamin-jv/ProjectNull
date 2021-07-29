using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class Destroy : MonoBehaviour
{
    public static void DestroyObj(GameObject gameObj){
        NetworkServer.Destroy(gameObj);
    }
}
