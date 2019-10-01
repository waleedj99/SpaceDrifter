using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipRes : MonoBehaviour
{
    public int food,initialFuel,initialFood;
    public float fuel;
    public bool isWon;
    public SimpleHealthBar fuelBar;
    SceneController sceneController;
    public bool movement;

    void Start()
    {
        sceneController = GameObject.Find("SceneManager").GetComponent<SceneController>(); 
        fuelBar = GameObject.Find("FuelBar").transform.Find("Status Fill 01").GetComponent<SimpleHealthBar>();
        movement = true;
        fuel = initialFuel;
        food = initialFood;
    }

    // Update is called once per frame
    void Update()
    {
        if(fuel<=0){
            sceneController.isPause = true;
            isWon = false;
            
        }
        else if(movement){
            GetComponent<AudioSource>().Stop();
            GetComponent<Transform>().position += new Vector3(0,0.05f,0);
            if(!sceneController.GrabberOn){
                fuel -= Time.deltaTime;
                Debug.Log("x1");
                SceneController.fuelMultiplier = 1;
                fuelBar.UpdateBar(fuel, initialFuel);
            }
        }else{
            if(!GetComponent<AudioSource>().isPlaying)
                GetComponent<AudioSource>().Play();
        }
    }
}
