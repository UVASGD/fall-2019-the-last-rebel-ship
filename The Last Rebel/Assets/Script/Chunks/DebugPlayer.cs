using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebugPlayer : MonoBehaviour
{

    private Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.UpArrow)) {
            transform.position += Vector3.up * ChunkManager.CHUNK_SIZE;
        }
        if (Input.GetKeyDown(KeyCode.DownArrow)) {
            transform.position += Vector3.down * ChunkManager.CHUNK_SIZE;
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow)) {
            transform.position += Vector3.left * ChunkManager.CHUNK_SIZE;
        }
        if (Input.GetKeyDown(KeyCode.RightArrow)) {
            transform.position += Vector3.right * ChunkManager.CHUNK_SIZE;
        }
    }
}
