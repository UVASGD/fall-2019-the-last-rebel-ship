using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Death : MonoBehaviour
{
    //public ParticleSystem deathParticles;

    // Start is called before the first frame update
    private void OnCollisionEnter2D(Collision2D other)
    {

        StartCoroutine(DeathParticles());
        SceneManager.LoadScene("Death Scene");
    }

    IEnumerator DeathParticles()
    {
        //deathParticles.Play;
        yield return new WaitForSeconds(5);
    }
}
