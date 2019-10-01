using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AssignCrew : MonoBehaviour
{
    public bool isAssign,isSearching,isMove;
    public SimpleHealthBar foodBar;
    ShipRes shipRes;
    SceneController Sc;
   
    CrewProps Cp;
    public ParticleSystem incHealthEffect;
    public GameObject WindowTrigger;
    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Pilot"))
        {
            if (Input.GetMouseButtonDown(1) && !Sc.GrabberOn)
            {
                if(Cp.food != Cp.initialFood && shipRes.food>5){
                    var diff = Cp.initialFood - Cp.food; 
                    if(diff<5){
                        incHealthEffect.Play();
                        Cp.food += diff;
                        shipRes.food-=diff;
                        var current = shipRes.food;
                        var max = shipRes.initialFood;
                        foodBar.UpdateBar(current, max);
                        
                    }else
                    {
                        incHealthEffect.Play();
                        shipRes.food -= 5;
                        var current = shipRes.food;
                        var max = shipRes.initialFood;
                        foodBar.UpdateBar(current, max);
                        Cp.food += 5;
                    }
                }
                    
                //Remove from shipRes
                
                //Debug.Log("minus ship res");

            }
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        foodBar = GameObject.Find("FoodBar").transform.Find("Status Fill 01").GetComponent<SimpleHealthBar>();
        Sc = GameObject.Find("SceneManager").GetComponent<SceneController>();
        shipRes = GameObject.Find("Ship").GetComponent<ShipRes>();
        isMove = true;
        incHealthEffect = GetComponent<ParticleSystem>();
        Cp = GetComponent<CrewProps>();
        WindowTrigger.GetComponent<ActivateBlock>().enableView = false;
        isAssign = true;
    }

    private void GoToTrigger(GameObject item){
        transform.position = Vector3.MoveTowards(transform.position, item.GetComponent<Transform>().position, 0.2f);
        transform.parent = item.transform;
        if (transform.position == item.GetComponent<Transform>().position)
        {
            if(item.name!="SceneManager")
            item.GetComponent<ActivateBlock>().enableView = true;
            isMove = false;

        }
    }
    // Update is called once per frame
    void Update()
    {
        if(isMove){
            GoToTrigger(WindowTrigger);
        }
        if(isAssign ==false){
            Destroy(gameObject);
            WindowTrigger.GetComponent<ActivateBlock>().enableView = false;
           
        }
        
    }
}
