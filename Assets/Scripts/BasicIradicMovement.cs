using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicIradicMovement : MonoBehaviour
{

    float speed;
    int RandomY;


    void Start()
    {
        speed = 2.5f;

        RandomY = Mathf.FloorToInt(Random.Range(0, 360));
        transform.rotation = Quaternion.Euler(0, RandomY, 0);
    }

    
    void Update()
    {
        transform.position += transform.forward * Time.deltaTime * speed;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "WallZ+")
        {
            RandomY = Mathf.FloorToInt(Random.Range(185, 255));
            transform.rotation = Quaternion.Euler(0, RandomY, 0);
        }else if (collision.gameObject.name == "WallZ-")
        {
            RandomY = Mathf.FloorToInt(Random.Range(-75, 75));
            transform.rotation = Quaternion.Euler(0, RandomY, 0);
        }
        else if (collision.gameObject.name == "WallX+")
        {
            RandomY = Mathf.FloorToInt(Random.Range(-165, -15));
            transform.rotation = Quaternion.Euler(0, RandomY, 0);
        }
        else if (collision.gameObject.name == "WallX-")
        {
            RandomY = Mathf.FloorToInt(Random.Range(15, 165));
            transform.rotation = Quaternion.Euler(0, RandomY, 0);
        }else if (collision.gameObject.CompareTag("Human"))
        {
            RandomY = Mathf.FloorToInt(Random.Range(0, 360));
            transform.rotation = Quaternion.Euler(0, RandomY, 0); 
        }
    }
}
