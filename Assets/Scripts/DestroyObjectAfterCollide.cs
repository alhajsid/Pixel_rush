using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyObjectAfterCollide : MonoBehaviour
{
    [SerializeField] float time = 1f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            Destroy(gameObject, time); ;
        }
    }

}
