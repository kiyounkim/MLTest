using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.MLAgents;
using Unity.MLAgents.Sensors;
using Unity.MLAgents.Actuators;

public class Player : Agent
{
    Rigidbody2D rb;
    public GameObject Target;
    public GameObject GM;
    public GameObject Life;
    public float speed;
    public GameObject missilePrefab;
    public Transform missileSpawnPoint;
    bool coolTime = true;
    // Start is called before the first frame update
    void Start()
    {
        rb=GetComponent<Rigidbody2D>();
    }

    public override void OnEpisodeBegin()
    {
        rb.velocity=Vector2.zero;
        transform.position = new Vector3(0,-3,0);
        //destroy all the asteroids
        GameObject[] asteroids = GameObject.FindGameObjectsWithTag("Target");
        foreach(GameObject ast in asteroids){
            Destroy(ast);
        }
        Life.GetComponent<Life>().health=3;

    }

    public override void CollectObservations(VectorSensor sensor)
    {
        sensor.AddObservation(transform.position);
        sensor.AddObservation(rb.velocity);
        sensor.AddObservation(Target.transform.position);
    }

    public override void OnActionReceived(ActionBuffers actionBuffers)
    {
        int horizontalControlSignal = actionBuffers.DiscreteActions[0];
        int verticalControlSignal = actionBuffers.DiscreteActions[1];
        rb.velocity = new Vector2(horizontalControlSignal * speed, verticalControlSignal * speed);
        if(actionBuffers.DiscreteActions[2]==1)
            Shoot();
    }

    public override void Heuristic(in ActionBuffers actionsOut)
    {
        var discreteActionsOut = actionsOut.DiscreteActions;
        int horizontalInput = (int)(Input.GetAxis("Horizontal") * speed);
        int verticalInput = (int)(Input.GetAxis("Vertical") * speed);
        int shootInput = (int)Input.GetAxis("Jump"); 
        discreteActionsOut[0] = horizontalInput;
        discreteActionsOut[1] = verticalInput;
        discreteActionsOut[2] = shootInput;
    }
    void Shoot(){
        if(coolTime){
            GameObject missile = Instantiate(missilePrefab, missileSpawnPoint.position, Quaternion.identity);
            coolTime=false;
            Invoke("CoolDown",0.5f);
        }
    }
    void CoolDown(){
        coolTime=true;
    }
}