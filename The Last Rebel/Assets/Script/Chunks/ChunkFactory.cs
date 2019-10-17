using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChunkFactory : MonoBehaviour
{

    public GameObject[] possibleChunks;

    void Start() {

    }

    void Update() {

    }

    public Chunk ProduceChunk() {
        int rand = Random.Range(0, possibleChunks.Length);

        GameObject chunk = possibleChunks[rand];

        GameObject instchunk = Instantiate(chunk);

        return instchunk.GetComponent<Chunk>();
    }
}
