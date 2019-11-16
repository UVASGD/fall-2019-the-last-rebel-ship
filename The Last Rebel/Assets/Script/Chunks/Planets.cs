using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Planets : Chunk
{
    public float bonusChance;

    public GameObject planet;
    public GameObject asteroid;
    public int asteroidsPerPlanet;
    public float asteroidRadius;

    // Start is called before the first frame update
    protected override void Start() {

    }

    // Update is called once per frame
    protected override void Update() {

    }

    public override void Allocate() {
        base.Allocate();

        do {

            Vector2 spawnloc = new Vector2(GetSeededRandomNumber(), GetSeededRandomNumber()) - new Vector2(0.5f, 0.5f);

            spawnloc *= 0.5f * ChunkManager.CHUNK_SIZE;

            GameObject spawnedPlanet = Instantiate(planet) as GameObject;

            spawnedPlanet.transform.parent = this.transform;
            spawnedPlanet.transform.localPosition = spawnloc;

            float mass = spawnedPlanet.GetComponent<Rigidbody2D>().mass;

            for(int i = 0; i < asteroidsPerPlanet; i++) {
                float r = (GetSeededRandomNumber() - 0.5f) + asteroidRadius;
                float theta = 2 * Mathf.PI * GetSeededRandomNumber();

                GameObject spawnedAsteroid = Instantiate(asteroid) as GameObject;

                Vector2 astloc = new Vector2(r * Mathf.Cos(theta), r * Mathf.Sin(theta));
                Vector2 astvel = new Vector2(-Mathf.Sin(theta), Mathf.Cos(theta));

                float speed = Mathf.Sqrt(mass * 0.1f / r);

                astvel *= speed;

                spawnedAsteroid.transform.parent = this.transform;
                spawnedAsteroid.transform.localPosition = spawnloc + astloc;

                spawnedAsteroid.GetComponent<Rigidbody2D>().velocity = astvel;

            }
        } while (GetSeededRandomNumber() < bonusChance);
    }

    public override void DeAllocate() {
        Destroy(gameObject);
    }
}
