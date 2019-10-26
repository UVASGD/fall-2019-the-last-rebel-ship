using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EnemyMove : MonoBehaviour
{
    public float speed;
    private Transform ship;
    private Transform target;
    Vector3 add;
    Vector3 sub;
    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        
        // Does the ray intersect any objects excluding the player layer
        int layerMask = 2;

        Vector3 raycastDir = target.position - transform.position;

        BoxCollider2D collider = (BoxCollider2D)this.gameObject.GetComponent<Collider2D>();

        float top = collider.offset.y + (collider.size.y / 2f);
        float btm = collider.offset.y - (collider.size.y / 2f);
        float left = collider.offset.x - (collider.size.x / 2f);
        float right = collider.offset.x + (collider.size.x / 2f);

        Vector3 topLeft = transform.TransformPoint(new Vector3(left, top, 0f));
        Vector3 topRight = transform.TransformPoint(new Vector3(right, top, 0f));
        Vector3 btmLeft = transform.TransformPoint(new Vector3(left, btm, 0f));
        Vector3 btmRight = transform.TransformPoint(new Vector3(right, btm, 0f));

        Debug.DrawRay(topLeft, raycastDir, Color.red);
        Debug.DrawRay(topRight, raycastDir, Color.cyan);
        RaycastHit2D hit = Physics2D.Raycast(transform.position, raycastDir);


        var right45 = (transform.forward + transform.right).normalized;
        var left45 = (transform.forward - transform.right).normalized;

        Debug.DrawRay(transform.position, right45, Color.green);
        Debug.DrawRay(transform.position, left45, Color.blue);
        Debug.DrawRay(transform.position, raycastDir, Color.white);
        Debug.Log(left45);
        var dir = target.position - transform.position;
        var angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle - 90, Vector3.forward);
        if (Physics2D.Raycast(transform.position, raycastDir, layerMask))
        {
            if (!Physics2D.Raycast(topLeft, raycastDir, layerMask))
            {
                //move right
                transform.position = Vector2.MoveTowards(transform.position, right45, speed * Time.deltaTime);
            }
            else if (!Physics2D.Raycast(topRight, raycastDir, layerMask))
            {
                //move left
                transform.position = Vector2.MoveTowards(transform.position, left45, speed * Time.deltaTime);
            }
            else
            {
                transform.position = Vector2.MoveTowards(transform.position, left45, speed * Time.deltaTime);
            }
        }


        else
        {

            transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
            //Debug.Log("Did not Hit");
        }

    }
}




