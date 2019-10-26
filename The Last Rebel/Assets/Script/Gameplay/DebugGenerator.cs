using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebugGenerator : MonoBehaviour
{

    public int numberToSpawn = 100;

    public float size;

    public GameObject prefab;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space)) {
            for(int i = 0; i < numberToSpawn; i++) {
                Vector2 position = new Vector2(Random.value - 0.5f, Random.value - 0.5f) * size;

                GameObject nobject = Instantiate(prefab, this.transform);

                nobject.transform.localPosition = position;
            }
        }
    }
}
