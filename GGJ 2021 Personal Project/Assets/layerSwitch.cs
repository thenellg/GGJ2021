using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class layerSwitch : MonoBehaviour
{
    public GameObject mainLevel;
    public GameObject backLevel;
    public Animator mainLevelAnim;
    
    [SerializeField] private bool onMainLevel = true;
    [SerializeField] private bool changeable = false;

    private void Start()
    {
        backLevel.GetComponent<TilemapCollider2D>().enabled = false;
    }

    private void Update()
    {
        if (changeable)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                changeLevels();
            }
        }
    }

    private void changeLevels()
    {
        if (onMainLevel)
        {
            mainLevelAnim.SetTrigger("hideMain");

            backLevel.GetComponent<TilemapCollider2D>().enabled = true;
            mainLevel.GetComponent<TilemapCollider2D>().enabled = false;

            onMainLevel = false;
        }
        else
        {
            mainLevelAnim.SetTrigger("showMain");

            backLevel.GetComponent<TilemapCollider2D>().enabled = false;
            mainLevel.GetComponent<TilemapCollider2D>().enabled = true;

            onMainLevel = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //show prompt
        if (collision.tag == "Player")
            changeable = true;
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Player")
            changeable = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        //hide prompt
        if (collision.tag == "Player")
            changeable = false;
    }
}
