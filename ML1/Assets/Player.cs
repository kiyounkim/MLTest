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
    public float speed;
    public GameObject missilePrefab;
    public Transform missileSpawnPoint;

    // Start is called before the first frame update
    void Start()
    {
        rb=GetComponent<Rigidbody2D>();
    }
    void Update(){
        if(Input.GetKeyDown(KeyCode.Space)){
            Shoot();
        }
    }

    public override void OnEpisodeBegin()
    {
        rb.velocity=Vector2.zero;
        transform.position = new Vector3(0,-3,0);
    }

    public override void CollectObservations(VectorSensor sensor)
    {
        sensor.AddObservation(transform.position);
        sensor.AddObservation(rb.velocity);
    }

    public override void OnActionReceived(ActionBuffers actionBuffers)
    {
        int controlSignal = actionBuffers.DiscreteActions[0];
        rb.velocity = new Vector2(controlSignal * speed, 0);
    }

    public override void Heuristic(in ActionBuffers actionsOut)
    {
        var discreteActionsOut = actionsOut.DiscreteActions;
        int horizontalInput = (int)(Input.GetAxis("Horizontal") * speed);
        discreteActionsOut[0] = horizontalInput;
    }
    void Shoot(){
        GameObject missile = Instantiate(missilePrefab, missileSpawnPoint.position, Quaternion.identity);
    }
}