using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    SceneController Sc;
    bool isGrabberOn;
    // Start is called before the first frame update
    void Start()
    {
        Sc = GameObject.Find("SceneManager").GetComponent<SceneController>();
        
    }

    // Update is called once per frame
    void Update()
    {
        isGrabberOn = Sc.GrabberOn;
        if(!isGrabberOn){
            var axis  =  new Vector2(Input.GetAxis("Horizontal"),Input.GetAxis("Vertical"));
            gameObject.GetComponent<Rigidbody2D>().velocity = axis*10;
            if(Input.GetKeyDown(KeyCode.A))
                gameObject.GetComponent<Transform>().rotation = Quaternion.Euler(0, 0, 90);
            if(Input.GetKeyDown(KeyCode.D)){
                gameObject.GetComponent<Transform>().rotation = Quaternion.Euler(0,0,-90);
            }
            if (Input.GetKeyDown(KeyCode.W))
                gameObject.GetComponent<Transform>().rotation = Quaternion.Euler(0, 0, 0);
            if (Input.GetKeyDown(KeyCode.S))
            {
                gameObject.GetComponent<Transform>().rotation = Quaternion.Euler(0, 0, -180);
            }
            
            
        }else{
            gameObject.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        }
    }
}
