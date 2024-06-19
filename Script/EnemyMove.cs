using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    [SerializeField] private float speed = 0.65f;

    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, 25f); //Destory after 8 Seconds
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += Vector3.left * speed * Time.deltaTime;
    }
}
