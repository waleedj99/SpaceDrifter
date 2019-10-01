using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrewProps : MonoBehaviour
{
    public int initialFood,initialTimer;
    public int food,timer;
    SpriteRenderer spriteRenderer;
    Color32 spriteColor;
    AssignCrew Ac;
    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        timer = initialTimer;
        spriteColor = spriteRenderer.color;
        Ac = GetComponent<AssignCrew>();
        food = initialFood;
    }

    // Update is called once per frame
    void Update()
    {

        timer--;
        if(timer<0){
            food--;
            timer = initialTimer;
        }
        if(food<0){
            Ac.isAssign  = false;
        }
        
        spriteColor =  new Color32((byte)food,0,0,255);
        spriteRenderer.color = spriteColor;
    }
}
