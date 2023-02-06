using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MonoBehaviour
{
    public GameObject Player;
    // Start is called before the first frame update
    void Start()
    {
        Player=GameObject.FindWithTag("Player");
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag != "Wall")
            Destroy(gameObject);
        else if(collision.gameObject.tag == "Player"){
            Player.GetComponent<Player>().AddReward(-0.1f);
            Destroy(gameObject);
        }
    }
}
