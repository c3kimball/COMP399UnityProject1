using System.Collections;
using System.Collections.Generic;
using System.Threading;
using TMPro;
using UnityEngine;

public class Move : MonoBehaviour
{
    public int score;
    public TMP_Text scoreText;
    public GameObject pauseText;
    private bool countdown;
    private float quitTimer;

    // Start is called on the first frame only.
    void Start()
    {
        score = 0;
        pauseText.SetActive(false);
        countdown = false;
        quitTimer = 0f;
    }

    // Update is called once per frame
    void Update()
    {
           /*
        if (Input.GetKey(KeyCode.UpArrow))
        {
            transform.position += new Vector3(0, 0, speed);
        }


        if (Input.GetKey(KeyCode.DownArrow))
        {
            transform.position += new Vector3(0, 0, -speed);

        }

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.position += new Vector3(-speed, 0, 0);
        }


        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.position += new Vector3(speed, 0, 0);
        }
           */
        float speed = 10f * Time.deltaTime;
        float horizMove = Input.GetAxisRaw("Horizontal") * speed;
        float vertMove = Input.GetAxisRaw("Vertical") * speed;
        transform.position += new Vector3(horizMove, 0, vertMove);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            // GetKeyDown is good for a toggle, for it is only true the first frame
            if (Time.timeScale == 0)
            {
                // unpausing
                pauseText.SetActive(false);
                Time.timeScale = 1;
            }
            else
            {
                pauseText.SetActive(true);
                Time.timeScale = 0;
            }

        }

        if (Input.GetKeyDown(KeyCode.Q))
        {
            countdown = true;
        }

        if (countdown)
        {
            // timer stuff
            if (quitTimer < 3)
            {
                quitTimer += Time.deltaTime;
                Debug.Log(quitTimer);
            }
            else
            {
                // while playing a game outside of editor use APplication.Quit()
                // but while in editor use:
                UnityEditor.EditorApplication.isPlaying = false;
            }

        }
    }

    private void OnTriggerEnter(Collider other)
    {
        // This script is from the perspective of the sphere
        // so other is the thing colliding with the sphere
        Debug.Log("Trigger entered!");
        float newX = Random.Range(-12, 12);
        float newZ = Random.Range(-5, 5);
        other.transform.position = new Vector3(newX, 0 + 1, newZ);

        ++score;
        scoreText.text = "Score: " + score;
    }

    private void OnTriggerStay(Collider other)
    {
        Debug.Log("Still in trigger.");
    }


}
