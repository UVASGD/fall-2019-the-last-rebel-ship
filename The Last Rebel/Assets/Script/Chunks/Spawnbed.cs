using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawnbed : Chunk
{

    public float bonusChance;

    public GameObject spawner;

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

            GameObject spawned = Instantiate(spawner) as GameObject;

            spawned.transform.parent = this.transform;
            spawned.transform.localPosition = spawnloc;
        } while (GetSeededRandomNumber() < bonusChance);
    }

    public override void DeAllocate() {
        Destroy(gameObject);
    }
}
