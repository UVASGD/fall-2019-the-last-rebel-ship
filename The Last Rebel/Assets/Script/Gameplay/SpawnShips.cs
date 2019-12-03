using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnShips : MonoBehaviour
{
    public Transform spawnPointN;
    public Transform spawnPointE;
    public Transform spawnPointS;
    public Transform spawnPointW;
    public GameObject shipPrefab;
    public float shipLanuchForce = 20f;
    public float maxCooldown = 10f;
    public float currentCooldown = -1f;

    // Update is called once per frame
    void Update()
    {
        if (currentCooldown < 0)
        {
            Spawn();
            currentCooldown = maxCooldown;
        }
        else
        {
            currentCooldown -= Time.deltaTime;
        }
    }
    void Spawn()
    {
        GameObject shipn = Instantiate(shipPrefab, spawnPointN.position, spawnPointN.rotation);
        Rigidbody2D rbn = shipn.GetComponent<Rigidbody2D>();
        rbn.velocity = GetComponent<Rigidbody2D>().velocity;
        rbn.AddForce((new Vector2(0, shipLanuchForce)));

        GameObject shipe = Instantiate(shipPrefab, spawnPointE.position, spawnPointE.rotation);
        Rigidbody2D rbe = shipe.GetComponent<Rigidbody2D>();
        rbe.velocity = GetComponent<Rigidbody2D>().velocity;
        rbe.AddForce((new Vector2(shipLanuchForce, 0)));

        GameObject ships = Instantiate(shipPrefab, spawnPointS.position, spawnPointS.rotation);
        Rigidbody2D rbs = ships.GetComponent<Rigidbody2D>();
        rbs.velocity = GetComponent<Rigidbody2D>().velocity;
        rbs.AddForce((new Vector2(0, -1 * shipLanuchForce)));

        GameObject shipw = Instantiate(shipPrefab, spawnPointW.position, spawnPointW.rotation);
        Rigidbody2D rbw = shipw.GetComponent<Rigidbody2D>();
        rbw.velocity = GetComponent<Rigidbody2D>().velocity;
        rbw.AddForce((new Vector2(-1 * shipLanuchForce, 0)));
    }
}
