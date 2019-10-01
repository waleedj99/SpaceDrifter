using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class GrabberMovement : MonoBehaviour
{
    // Start is called before the first frame update
    public bool isGrabberOn;
    Transform grabberTrans;
    ShipRes ShipRes;
    SceneController Sc;
    public Transform clawLeft,clawRight;
    
    void Start()
    {
        ShipRes  = GameObject.Find("Ship").GetComponent<ShipRes>();
        isGrabberOn = GameObject.Find("SceneManager").GetComponent<SceneController>().GrabberOn;
        Sc = GameObject.Find("SceneManager").GetComponent<SceneController>();
        grabberTrans = gameObject.GetComponent<Transform>(); 
    }

    // Update is called once per frame
    void Update()
    {
        
        isGrabberOn = Sc.GrabberOn;
        if(isGrabberOn){
            ShipRes.fuel -= 2*Time.deltaTime ;
            ShipRes.movement = true;
            Debug.Log("x2");
            SceneController.fuelMultiplier = 2;
           
        }
        clawLeft.localRotation = Quaternion.Euler(0,0,0);
        clawRight.localRotation = Quaternion.Euler(0, 0, 0);
        if(isGrabberOn){
            Vector3 onGrabPosition = new Vector3(0.176f, 0.08f, -0.050f);
            if(Input.GetMouseButton(0)){
                clawLeft.localPosition = onGrabPosition;
                clawRight.localPosition = new Vector3(0.176f, -0.08f, -0.050f); 

                GameObject.Find("Sensor").GetComponent<BoxCollider2D>().enabled = true;
                GameObject.Find("GrabberText").GetComponent<TextMeshProUGUI>().enabled = true;
            }else{
                GameObject.Find("Sensor").GetComponent<BoxCollider2D>().enabled = false;
                GameObject.Find("GrabberText").GetComponent<TextMeshProUGUI>().enabled = false;
                clawLeft.localPosition = new Vector3(0.176f,0.11f,-0.05f);
                clawRight.localPosition = new Vector3(0.176f, -0.11f, -0.05f);
            }
            if(Input.GetKey(KeyCode.W)){
                grabberTrans.Translate(0.3f, 0, 0);
            }
            if (Input.GetKey(KeyCode.S))
            {
                grabberTrans.Translate(-0.3f, 0, 0);
            }
            if (Input.GetKey(KeyCode.A))
            {
                grabberTrans.Rotate(0,0,2); 
            }
            if (Input.GetKey(KeyCode.D))
            {
                grabberTrans.Rotate(0, 0, -2);
            }
            if (Input.GetKeyUp(KeyCode.S)||Input.GetKeyUp(KeyCode.W))
            {
                gameObject.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            }
        
    }
    }
}
