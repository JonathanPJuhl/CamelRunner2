using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cigeratte : MonoBehaviour
{
    [SerializeField] float rotation = 90f;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0,rotation * Time.deltaTime, 0);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<Obstacle>() != null)
        {
            Destroy(gameObject);
            return;
        }
        if (other.gameObject.name != "Player")
        {
            return;
        }

        GameManager1.inst.IncrementScore();

        Destroy(gameObject);
    }
}
