using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestoryScript : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject explosion;
    void Start()
    {
        GetComponentInChildren<ParticleSystem>().Stop();    
    }

    /// <summary>
    /// This function is called when the MonoBehaviour will be destroyed.
    /// </summary>
    private void OnCollisionEnter2D(Collision2D other) {
        if(other.gameObject.name=="Ship"||other.gameObject.name == "ShipTop"){
            var boom = Instantiate(explosion, transform.position, new Quaternion(0, 0, 0, 0));
            boom.GetComponent<AudioSource>().Play();
            Destroy(gameObject);
            Destroy(boom, 1f);
        }
    }
    void OnDestroy()
    {
        //var boom = Instantiate(explosion,transform.position,new Quaternion(0,0,0,0));
        //boom.GetComponent<AudioSource>().Play();
        
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
