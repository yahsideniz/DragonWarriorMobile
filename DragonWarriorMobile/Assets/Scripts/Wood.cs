using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wood : MonoBehaviour
{
    public int healt;
    public GameObject effect;
    


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(healt<=0)
        {
            Destroy(this.gameObject);
            Instantiate(effect, transform.position, Quaternion.identity);
            
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag=="Player")
        {
            healt -= 100;
        }
    }
}
