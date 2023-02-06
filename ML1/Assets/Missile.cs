using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Missile : MonoBehaviour
{
    public int speed;
    public GameObject Player;
    // Start is called before the first frame update
    void Start()
    {
        Player=GameObject.FindWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += new Vector3(0, speed * Time.deltaTime, 0);
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag != "Player")
        {
            Destroy(gameObject);
        }
        else if(collision.gameObject.tag == "Target"){
            Player.GetComponent<Player>().AddReward(0.1f);
        }
    } 
}
