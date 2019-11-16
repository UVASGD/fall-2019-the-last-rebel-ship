using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChunkManager : MonoBehaviour
{
    #region Static Fields

    public static readonly int MODULUS = 10;

    public static readonly float CHUNK_SIZE = 150;

    public static readonly int MAX_LOADED_CHUNKS = 30;

    #endregion

    #region Instance Fields

    public GameObject player;

    public ChunkFactory factory;

    private Vector2Int playerPosition;

    private Dictionary<Vector2Int, Chunk> chunks;

    #endregion

    #region Unity Methods

    // Start is called before the first frame update
    void Start() {
        if(!player) {
            player = GameObject.FindGameObjectWithTag("Player");
        }

        if(!factory) {
            factory = FindObjectOfType<ChunkFactory>();
        }

        chunks = new Dictionary<Vector2Int, Chunk>();

        playerPosition = new Vector2Int(
            (int)(player.transform.position.x / CHUNK_SIZE),
            (int)(player.transform.position.y / CHUNK_SIZE)
        );

        AllocateChunk(playerPosition);

        RecalculateChunks();
    }

    // Update is called once per frame
    void Update() {
        Vector2Int currPosition = new Vector2Int(
            (int)(player.transform.position.x / CHUNK_SIZE),
            (int)(player.transform.position.y / CHUNK_SIZE)
        );

        if(currPosition.x != playerPosition.x || currPosition.y != playerPosition.y) {
            playerPosition = currPosition;
            RecalculateChunks();
        }
    }

    #endregion

    #region Class Methods

    public void RecalculateChunks() {
        foreach(Vector2Int pos in Adjacents(playerPosition)) {
            AllocateChunk(pos);
        }
    }

    private void FreeChunk() {
        if (chunks.Count == 0) {
            Debug.Log("Something's fucky in the state of denmark");
            return;
        }

        Vector2Int max_position = playerPosition;

        foreach(Vector2Int pos in chunks.Keys) {
            if((playerPosition - pos).sqrMagnitude > (max_position - playerPosition).sqrMagnitude) {
                max_position = pos;
            }
        }

        Chunk toRemove = chunks[max_position];

        chunks.Remove(max_position);

        toRemove.DeAllocate();
    }

    private void AllocateChunk(Vector2Int position) {

        if(chunks.ContainsKey(position)) {
            return;
        }

        if (chunks.Count > MAX_LOADED_CHUNKS) {
            FreeChunk();
        }

        Chunk toAdd = factory.ProduceChunk();

        chunks[position] = toAdd;

        toAdd.SetPosition(position);
        toAdd.Allocate();
    }

    private Vector2Int[] Adjacents(Vector2Int position) {
        return new Vector2Int[] {
            new Vector2Int(position.x - 1, position.y - 1), new Vector2Int(position.x, position.y - 1)  , new Vector2Int(position.x + 1, position.y - 1),
            new Vector2Int(position.x - 1, position.y)    ,                                               new Vector2Int(position.x + 1, position.y),
            new Vector2Int(position.x - 1, position.y + 1), new Vector2Int(position.x, position.y + 1)  , new Vector2Int(position.x + 1, position.y + 1),
        };
    }

    #endregion
}
