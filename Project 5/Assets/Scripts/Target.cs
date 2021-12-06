using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    // Variables

    private Rigidbody targetRb;
    private float minSpeed = 12;
    private float maxSpeed = 16;
    private float maxTorque = 10;
    private float xRange = 4;
    private float ySpawnPos = -2;
    private GameManager gameManager;
    public int pointValue;
    public ParticleSystem explostionParticle;

    // Start is called before the first frame update
    void Start()
    {
        // Instantiates variables
        gameManager = GameObject.Find("Game Manager")
            .GetComponent<GameManager>();
        targetRb = GetComponent<Rigidbody>();

        // For every target instantiated, rotation and position  
        targetRb.AddForce(RandomForce(), ForceMode.Impulse);
        targetRb.AddTorque(RandomTorque(), RandomTorque(),
            RandomTorque(), ForceMode.Impulse);
        transform.position = RandomSpawnPos();
    }

    // Update is called once per frame
    void Update()
    {

    }


    // When target is clicked, destroys and updates score
    private void OnMouseDown()
    {
        if (gameManager.isGameActive)
        {
            Destroy(gameObject);
            Instantiate(explostionParticle, transform.position,
                explostionParticle.transform.rotation);
            gameManager.UpdateScore(pointValue);
        }
       
    }

    // When target falls, it gets destroyed
    private void OnTriggerEnter(Collider other)
    {
        Destroy(gameObject);
        if (!gameObject.CompareTag("Bad"))
        {
            gameManager.GameOver();
        }
    }

    // Sets position, rotation, and force
    Vector3 RandomForce()
    {
        return Vector3.up * Random.Range(minSpeed, maxSpeed);
    }

    float RandomTorque()
    {
        return Random.Range(-maxTorque, maxTorque);
    }

    Vector3 RandomSpawnPos()
    {
        return new Vector3(Random.Range(-xRange, xRange), ySpawnPos);
    }

}
