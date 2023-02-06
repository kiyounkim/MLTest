using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject astPrefab;
    public bool canSpawn = true;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Spawn();
    }
    void Spawn(){
        if(canSpawn){
            GameObject ast = Instantiate(astPrefab, new Vector3(Random.Range(-9,9),8,0), Quaternion.identity);
            canSpawn=false;
            Invoke("CoolDown",2f);
        }
    }
    void CoolDown(){
        canSpawn=true;
    }
}
