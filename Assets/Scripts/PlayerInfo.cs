using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerInfo : MonoBehaviour
{
    private float playerHP = 15;
    public int stop = 0;
    public Animator anima;

    private void Start()
    {
        //Sets up animator
        anima = gameObject.GetComponent<Animator>();
    }

    void Update()
    {
        if (playerHP <= 0)
        {
            //Goes to loss screen on Valharn death
            SceneManager.LoadScene(5);
            Destroy(this.gameObject);
        }

        if (SceneManager.GetActiveScene().buildIndex == 5)
        {
            playerHP = 0;
        }

        if (Invader.count == 15)
        {
            //If all invaders on wave 1 have been slain, advance wave
            Invader.count++;
            SceneManager.LoadScene(2);
        }

        if (Invader1.count == 30)
        {
            //If all invaders on wave 2 have been slain, advance wave
            Invader1.count++;
            SceneManager.LoadScene(3);
        }

        if (Invader2.count == 45)
        {
            //If all invaders on wave 3 have been slain, proceed to victory screen
            Invader2.count++;
            SceneManager.LoadScene(4);
        }

        //Plays animations depending on key press
        if (Input.anyKey == false)
        {
            anima.Play("Idle");
        }
        if (Input.GetKey(KeyCode.Space))
        {
            anima.Play("Jump");
        }
        if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.D))
        {
            anima.Play("Walk");
            if (Input.GetKeyDown(KeyCode.LeftShift))
            {
                anima.Play("Sprint");
            }
        }
        if (Input.GetMouseButton(0))
        {
            anima.Play("Attack");
        }

    }

    private void OnTriggerEnter(Collider collide)
    {
        //If invader collides with Valharn he will lose health
        if (collide.gameObject.tag.Contains("Invader"))
        {
            playerHP -= 1;
        }

        //If invader collides with Grape he will gain health
        if (collide.gameObject.tag.Contains("Grape"))
        {
            playerHP += 5;
        }
    }
}
