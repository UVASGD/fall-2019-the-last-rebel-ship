using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChunkFactory : MonoBehaviour
{

    public GameObject[] possibleChunks;

    public int[] weightings;

    private int totalWeights;

    void Start() {
        totalWeights = 0;
        for(int i = 0; i < weightings.Length && i < possibleChunks.Length; i++) {
            totalWeights += weightings[i];
        }
    }

    void Update() {

    }

    public Chunk ProduceChunk() {
        int rand = Random.Range(0, totalWeights);

        int chosen = -1;

        for(int i = 0; i < weightings.Length; i++) {
            rand -= weightings[i];
            if(rand < 0) {
                chosen = i;
                break;
            }
        }

        if(chosen == -1) {
            return null;
        }

        GameObject chunk = possibleChunks[chosen];

        GameObject instchunk = Instantiate(chunk);

        return instchunk.GetComponent<Chunk>();
    }
}
