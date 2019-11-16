using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Minefield : Chunk
{
    public int minMines;
    public int maxMines;

    public GameObject mine;

    // Start is called before the first frame update
    protected override void Start()
    {
        
    }

    // Update is called once per frame
    protected override void Update()
    {
        
    }

    public override void Allocate() {
        base.Allocate();

        int numMines = (int)(GetSeededRandomNumber() * (maxMines - minMines)) + minMines;

        for(int i = 0; i < numMines; i++) {
            float r = GetSeededRandomNumber() * 0.5f * ChunkManager.CHUNK_SIZE;
            float theta = 2 * Mathf.PI * GetSeededRandomNumber();

            Vector2 spawnloc = new Vector2(r * Mathf.Cos(theta), r * Mathf.Sin(theta));

            spawnloc += new Vector2(0.5f, 0.5f) * ChunkManager.CHUNK_SIZE;

            GameObject spawned = Instantiate(mine) as GameObject;

            spawned.transform.parent = this.transform;
            spawned.transform.localPosition = spawnloc;
        }
    }

    public override void DeAllocate() {
        Destroy(gameObject);
    }
}
