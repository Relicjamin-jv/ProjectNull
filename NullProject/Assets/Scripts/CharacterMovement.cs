using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    public float speed = 4f;
    private Vector3 _targetPostion;
    private bool isMoving;
    // Start is called before the first frame update
    void Start()
    {
     //null
    }

    void SetTargetPosition(){
        _targetPostion = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        _targetPostion.z = transform.position.z;

        isMoving = true;
    }

    void move(){
        transform.position = Vector3.MoveTowards(this.transform.position, _targetPostion, speed * Time.deltaTime);

        if(transform.position == _targetPostion){
            isMoving = false;
        }
    }
    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButton(0)){
            SetTargetPosition();
        }

        if(isMoving){
            move();
        }
    }
}
