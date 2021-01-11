using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    public int damage = 1;
    public float speed;
    public GameObject effect;
    public GameObject sound;

    private void Update()
    {
        transform.Translate(Vector2.left * speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Instantiate(effect, transform.position, Quaternion.identity);
        if (other.CompareTag("Player"))
        {
            other.GetComponent<Player>().health -= damage;
            Destroy(gameObject);
            Debug.Log("damage");
            Instantiate(sound, transform.position, Quaternion.identity);
        }
    }
}
