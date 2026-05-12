using System;
using UnityEngine;

public class BulletMove : MonoBehaviour
{
    [SerializeField] private float speed = 1f;

    // Update is called once per frame
    void Update()
    {
        transform.position += transform.forward * (speed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player"))
        {
            Destroy(this.gameObject);
        }

        if (other.CompareTag("Enemy"))
        {
            other.GetComponent<EnemyMovement>().Hit();
        }
    }
}
