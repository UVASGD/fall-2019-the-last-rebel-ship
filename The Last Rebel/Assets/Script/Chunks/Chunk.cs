using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chunk : MonoBehaviour
{

    #region Static Fields

    #endregion

    #region Instance Fields

    public int numStars;

    public GameObject star;

    protected Vector2Int position;
    private Random.State prng;

    #endregion

    #region Unity Methods

    // Start is called before the first frame update
    protected virtual void Start()
    {

    }

    // Update is called once per frame
    protected virtual void Update()
    {
        
    }

    #endregion

    #region Class Methods

    protected int GetID() {
        return (position.y % ChunkManager.MODULUS) * ChunkManager.MODULUS + (position.x % ChunkManager.MODULUS);
    }

    public void SetPosition(Vector2Int _position) {
        position = _position;

        gameObject.transform.position = new Vector2(position.x * ChunkManager.CHUNK_SIZE, position.y * ChunkManager.CHUNK_SIZE);

        Random.State exogenous_state = Random.state;

        Random.InitState(GetID());

        prng = Random.state;

        Random.state = exogenous_state;
    }

    protected float GetSeededRandomNumber() {
        Random.State exogenous_state = Random.state;

        Random.state = prng;

        float r = Random.value;

        prng = Random.state;

        Random.state = exogenous_state;

        return r;
    }

    public virtual void Allocate() {
        for(int i = 0; i < numStars; i++) {
            Vector2 spawnloc = new Vector2(GetSeededRandomNumber(), GetSeededRandomNumber()) - new Vector2(0.5f, 0.5f);
            spawnloc *= ChunkManager.CHUNK_SIZE;

            GameObject spawned = Instantiate(star) as GameObject;
            spawned.transform.parent = this.transform;
            spawned.transform.localPosition = spawnloc;
            //spawned.transform.localScale = 5 * new Vector2(1 + GetSeededRandomNumber(), 1 + GetSeededRandomNumber());
        }
    }

    public virtual void DeAllocate() {

    }

    #endregion
}
