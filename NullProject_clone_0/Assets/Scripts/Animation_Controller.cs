using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animation_Controller : MonoBehaviour
{
    private Animator _anim; //animator var

    private Vector3 _postion;
    // Start is called before the first frame update
    void Start()
    {
        _anim = GetComponent<Animator>(); //get the reference to the animation being used in the script
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        //seperation between point-to-click and wasd.

        if((this.transform.position.y) > _postion.y && Mathf.Abs(this.transform.position.y - _postion.y) > Mathf.Abs(this.transform.position.x - _postion.x)){ 
            _anim.SetBool("Is_Walking_Up", true);
        }else{
            _anim.SetBool("Is_Walking_Up", false);
        }

        if((this.transform.position.y) < _postion.y && Mathf.Abs(this.transform.position.y - _postion.y) > Mathf.Abs(this.transform.position.x - _postion.x)){
            _anim.SetBool("Is_Walking_Down", true);
        }else{
            _anim.SetBool("Is_Walking_Down", false);
        }

        if(this.transform.position.x < _postion.x && Mathf.Abs(this.transform.position.x - _postion.x) > Mathf.Abs(this.transform.position.y - _postion.y)){
            _anim.SetBool("Is_Walking_Left", true);
        }else{
            _anim.SetBool("Is_Walking_Left", false);
        }

        if(this.transform.position.x > _postion.x && Mathf.Abs(this.transform.position.x - _postion.x) > Mathf.Abs(this.transform.position.y - _postion.y)){
            _anim.SetBool("Is_Walking_Right", true);
        }else{
            _anim.SetBool("Is_Walking_Right", false);
        }
        _postion = this.transform.position;
    }

    //seperation between point-to-click and wasd.
}
