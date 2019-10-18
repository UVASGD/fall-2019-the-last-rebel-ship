using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DebugChunk : Chunk
{

    public RectTransform canvasTransform;
    public Text text;

    /*protected override void Start() {
        base.Start();
        SetPosition(new Vector2Int(0, 0));
        Allocate();
    }*/

    public override void Allocate() {
        base.Allocate();
        canvasTransform.localScale = new Vector3(1, 1, 1) * ChunkManager.CHUNK_SIZE / canvasTransform.rect.width;
        text.text = "Chunk: " + GetID() + "\n " + GetSeededRandomNumber();
    }

    public override void DeAllocate() {
        base.DeAllocate();
        Destroy(gameObject);
    }
}
