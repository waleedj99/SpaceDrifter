using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstantiateDebri : MonoBehaviour
{
    // Start is called before the first frame update
    Transform LeftPos,RightPos;
    int spawnTime;
    public GameObject[] Resource;
    public GameObject[] Debri;
    void Start()
    {
        spawnTime = 100;
        RightPos = GameObject.Find("RightAnchorDrop").GetComponent<Transform>();
        LeftPos = GameObject.Find("LeftAnchorDrop").GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        spawnTime--;
        var InstantiatePosition = Random.Range(RightPos.transform.position.x,LeftPos.transform.position.x);
        var InstantiateRotation = Random.Range(0,360);
        if(spawnTime<0){
            var chance = Random.Range(0,100);
            if(chance<55){
                var clone  = Instantiate(Debri[Random.Range(0, Debri.Length)],new Vector3(InstantiatePosition,RightPos.transform.position.y,RightPos.transform.position.z),Quaternion.Euler(0,0,InstantiateRotation));
                clone.GetComponent<Transform>().localScale = new Vector3(Random.Range(0.8f,1.8f),Random.Range(0.8f, 1.8f),1);
                clone.GetComponentInChildren<ParticleSystem>().Stop();
                clone.AddComponent<Rigidbody2D>().gravityScale=0.02f;
                //clone.AddComponent<Rigidbody2D>().useAutoMass = true;
                clone.GetComponent<Rigidbody2D>().mass = clone.GetComponent<Transform>().localScale.x * clone.GetComponent<Transform>().localScale.y; 
                clone.AddComponent<CircleCollider2D>();
            }else if(chance<90 && chance>60){
                var clone = Instantiate(Resource[Random.Range(0,Resource.Length)], new Vector3(InstantiatePosition, RightPos.transform.position.y, RightPos.transform.position.z), Quaternion.Euler(0, 0, InstantiateRotation));
                clone.GetComponent<Transform>().localScale = new Vector3(5, 10, 1);
                clone.GetComponent<Rigidbody2D>().gravityScale = 0.1f;
                clone.AddComponent<BoxCollider2D>();
            }
            spawnTime = 150;
            
        }
    }
}
