using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinScript : MonoBehaviour
{
    Transform shipTransform,winTransform;
    
    SceneController sceneController;
    ShipRes shipRes;
    // Start is called before the first frame update
    void Start()
    {
        winTransform = GetComponent<Transform>();
        shipTransform = GameObject.Find("Ship").GetComponent<Transform>();
        shipRes = GameObject.Find("Ship").GetComponent<ShipRes>();
        sceneController = GameObject.Find("SceneManager").GetComponent<SceneController>();
    }
void OnTriggerEnter2D(Collider2D other)
    {
        
        if(other.gameObject.name=="DebriSpawn"){
            Destroy(other.gameObject);
        }
            Debug.Log("hmm");
            sceneController.isPause = true;
            shipRes.isWon = true;
       
    }
    // Update is called once per frame
    void Update()
    {
        winTransform.localPosition = new Vector3(shipTransform.localPosition.x,winTransform.localPosition.y,winTransform.localPosition.z);
    }
}
