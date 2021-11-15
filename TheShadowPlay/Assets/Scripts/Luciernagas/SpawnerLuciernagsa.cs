using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerLuciernagsa : MonoBehaviour
{
    // Start is called before the first frame update
    public Rigidbody luciernaga;
    bool disparando;
    public int numluciernagas;
    public List<GameObject> luciernagas;

    void Update()
    {
        if (disparando == false&&numluciernagas!=luciernagas.Count)
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

       
        yield return new WaitForSeconds(3f);
        disparando = false;

    }
}
