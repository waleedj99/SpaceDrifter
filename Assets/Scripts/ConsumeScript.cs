using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConsumeScript : MonoBehaviour
{
    public SimpleHealthBar foodBar;
    public SimpleHealthBar fuelBar;
    ShipRes ShipRes;
    DrawLine DrawLine;
    float current,max;
    // Start is called before the first frame update
    private void OnTriggerStay2D(Collider2D other){
       
        if(DrawLine.consumeTime){
           
            if(other.CompareTag("Food")){
                if(ShipRes.food != ShipRes.initialFood){
                    var diff = ShipRes.initialFood - ShipRes.food; 
                    if(diff<20){
                        ShipRes.food += diff;
                        current = ShipRes.food;
                        max = ShipRes.initialFood;
                        foodBar.UpdateBar(current, max);
                    }else
                    {
                        ShipRes.food += 20;
                        current = ShipRes.food;
                        max = ShipRes.initialFood;
                        foodBar.UpdateBar(current, max);
                    }
                }
                GetComponent<ParticleSystem>().Play();    
                Destroy(other.gameObject);

            }
            if(other.CompareTag("Fuel")){
                if (ShipRes.fuel != ShipRes.initialFuel)
                {
                    var diff = ShipRes.initialFuel - ShipRes.fuel;
                    if (diff < 20)
                    {
                        ShipRes.fuel += diff;
                        current = ShipRes.fuel;
                        max = ShipRes.initialFuel;
                        fuelBar.UpdateBar(current, max);
                    }
                    else
                    {
                        ShipRes.fuel += 20;
                        current = ShipRes.fuel;
                        max = ShipRes.initialFuel;
                        fuelBar.UpdateBar(current, max);
                    }
                }
                GetComponent<ParticleSystem>().Play();
                Destroy(other.gameObject);
            }
            if(other.CompareTag("Both")){
                if (ShipRes.food != ShipRes.initialFood)
                {
                    var diff = ShipRes.initialFood - ShipRes.food;
                    if (diff < 20)
                    {
                        ShipRes.food += diff;
                    }
                    else
                    {
                        ShipRes.food += 20;
                    }
                }
                
                if (ShipRes.fuel != ShipRes.initialFuel)
                {
                    var diff = ShipRes.initialFuel - ShipRes.fuel;
                    if (diff < 20)
                    {
                        ShipRes.fuel += diff;
                    }
                    else
                    {
                        ShipRes.fuel += 20;
                    }
                }
                Destroy(other.gameObject);
            }
            }
    }
    void Start()
    {
        ShipRes  = GameObject.Find("Ship").GetComponent<ShipRes>();
        fuelBar = GameObject.Find("FuelBar").transform.Find("Status Fill 01").GetComponent<SimpleHealthBar>();
        foodBar = GameObject.Find("FoodBar").transform.Find("Status Fill 01").GetComponent<SimpleHealthBar>();
        DrawLine = GameObject.Find("Grabber").GetComponent<DrawLine>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
