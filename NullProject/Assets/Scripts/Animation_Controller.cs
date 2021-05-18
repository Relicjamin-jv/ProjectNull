using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animation_Controller : MonoBehaviour
{
    private Animator _anim; //animator var
    // Start is called before the first frame update
    void Start()
    {
        _anim = GetComponent<Animator>(); //get the reference to the animation being used in the script
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.W)){ 
            _anim.SetBool("Is_Walking_Up", true);
        }else{
            _anim.SetBool("Is_Walking_Up", false);
        }

        if(Input.GetKey(KeyCode.S)){
            _anim.SetBool("Is_Walking_Down", true);
        }else{
            _anim.SetBool("Is_Walking_Down", false);
        }

        if(Input.GetKey(KeyCode.A)){
            _anim.SetBool("Is_Walking_Left", true);
        }else{
            _anim.SetBool("Is_Walking_Left", false);
        }

        if(Input.GetKey(KeyCode.D)){
            _anim.SetBool("Is_Walking_Right", true);
        }else{
            _anim.SetBool("Is_Walking_Right", false);
        }
    }
}
