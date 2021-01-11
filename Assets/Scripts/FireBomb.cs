using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBomb : MonoBehaviour
{
    public int damage = 1;
    public float speed;
    public float speed2;
    public GameObject effect;
    public GameObject sound;

    //public float stopAmount;
    public float stopTime;
    //public float timeAfterStop;
    private bool moveforward = true;
    private int hardCodedCounter = 0;
    public float xStopPoint;

    private void Update()
    {
        if (moveforward)
        {
            Move();
        }
        else
        {
            moveforward = false;
            StartCoroutine(UnPause());
        }

    }

    private void Move()
    {
        if (transform.position.x <= xStopPoint && hardCodedCounter == 0)
        {
            moveforward = false;
        }
        else if (hardCodedCounter == 1)
        {
            transform.Translate(Vector2.left * speed2 * Time.deltaTime);
            return;
        }
        else
        {
            transform.Translate(Vector2.left * speed * Time.deltaTime);
            return;
        }
    }

    IEnumerator UnPause()
    {
        yield return new WaitForSeconds(stopTime);
        Debug.Log("After Waiting " + stopTime + " Seconds");
        hardCodedCounter = 1;
        moveforward = true;
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
