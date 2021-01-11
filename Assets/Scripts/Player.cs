using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
using UnityEngine;


public class Player : MonoBehaviour
{
    private Vector2 targetPos;
    public float Yincrement;

    public float speed;
    public float maxHeight;
    public float minHeight;

    public int health = 3;
    public GameObject effects;
    public GameObject sound;
    public TextMeshProUGUI healthDisplay;

    public CircleCollider2D colliderSave;
    public CircleCollider2D colliderDestroy;
    public GameObject scorer;

    public GameObject life3;
    public GameObject life2;
    public GameObject life1;
    public GameObject restartMenu;
    public GameObject optionMenu;

    public GameObject character;

    //handle camera shaking
    public CameraShake cameraShake;

    private void Start()
    {
        Time.timeScale = 1f;
        colliderDestroy = colliderSave;
    }
    private void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, targetPos, speed * Time.deltaTime);
        healthDisplay.text = health.ToString();

        if (health == 2)
        {
            Destroy(life3);
        }
        if (health == 1)
        {
            Destroy(life2);
        }
        if (health == 0)
        {
            Destroy(life1);
        }

        //keep inside screen
        if(transform.position.y > maxHeight)
        {
            character.transform.position = new Vector2(0, maxHeight);
        }
        if (transform.position.y < minHeight)
        {
            character.transform.position = new Vector2(0, minHeight);
        }


        if (Input.GetKeyDown(KeyCode.UpArrow) && transform.position.y < maxHeight)
        {
            targetPos = new Vector2(transform.position.x, transform.position.y + Yincrement);
            Instantiate(effects, transform.position, Quaternion.identity);
            Instantiate(sound, transform.position, Quaternion.identity);

            StartCoroutine(cameraShake.Shake(0.15f, 0.2f));
        }

        else if (Input.GetKeyDown(KeyCode.DownArrow) && transform.position.y > minHeight)
        {
            targetPos = new Vector2(transform.position.x, transform.position.y - Yincrement);
            Instantiate(effects, transform.position, Quaternion.identity);
            Instantiate(sound, transform.position, Quaternion.identity);

            StartCoroutine(cameraShake.Shake(0.15f, 0.2f));
        }

        if (health <= 0)
        {
            //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            Time.timeScale = 0.15f;
            Destroy(scorer);
            colliderDestroy.enabled = false;
            restartMenu.SetActive(true);
            
        }

        if (optionMenu.activeSelf == true)
        {
            restartMenu.SetActive(false);
        }
    }
}
