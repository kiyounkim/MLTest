using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Missile : MonoBehaviour
{
    public int speed;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += new Vector3(0, speed * Time.deltaTime, 0);
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag != "Player"){
            Destroy(gameObject);
        }
        else if (collision.gameObject.tag == "Target"){
            //find the player and add reward
            GameObject.FindWithTag("Player").GetComponent<Player>().AddReward(0.1f);
            Destroy(gameObject);
        }
    } 
}
