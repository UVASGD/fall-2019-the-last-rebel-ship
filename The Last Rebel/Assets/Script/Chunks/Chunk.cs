using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chunk : MonoBehaviour
{

    #region Static Fields

    #endregion

    #region Instance Fields

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

    public void SetPosition(Vector2Int _position) {
        position = _position;

        gameObject.transform.position = new Vector2(position.x * ChunkManager.CHUNK_SIZE, position.y * ChunkManager.CHUNK_SIZE);

        Random.State exogenous_state = Random.state;

        Random.InitState((position.y % ChunkManager.MODULUS) * ChunkManager.MODULUS + (position.x % ChunkManager.MODULUS));

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

    }

    public virtual void DeAllocate() {

    }

    #endregion
}
