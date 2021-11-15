using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnLuciernaga : MonoBehaviour
{
    public Rigidbody luciernaga;
    bool disparando;


    void Update()
    {
        if (disparando == false)
        {
            StartCoroutine("Espera");
        }
    }

    IEnumerator Espera()
    {
        disparando = true;
        Rigidbody clone;

        clone = Instantiate(luciernaga, transform.position, transform.rotation);
        clone.gameObject.SetActive(true);

        
        yield return new WaitForSeconds(2f);
        disparando = false;

    }
}
