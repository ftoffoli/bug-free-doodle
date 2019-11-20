using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SpawnLetters : MonoBehaviour
{

    public float rateSpawn;
    public List<GameObject> prefab;
    public List<GameObject> list;
    public float letterLife;
    public List<Sprite> spriteSelection;

    private SpriteRenderer spriteRenderer;
    private float createRateSpawn;
    private int letter;
    private bool active = true;
    private bool last = true;
    private GameObject temp;
    private GameObject word;

    void Start()
    {

    }

    /*  When the timer achieves the currentRateSpawn, 
        the method spawn is called and the GameObject is setted as inactive
        Doing it, the GameObject will not be duplicated*/

    void Update()
    {
        createRateSpawn += Time.deltaTime;
        if(name=="letter")
            Destroy(gameObject, letterLife);
        if (createRateSpawn > rateSpawn)
        {
            createRateSpawn = 0;
            if (active == true)
            {
                spawn();
            }
            active = false;
        }
    }


    /* Create a temp GameObject, spawn it a random position and change the sprite
        * */
    private void spawn()
    { 
        temp = Instantiate(prefab[0]) as GameObject;
        temp.name = "letter";
        if (temp != null)
        {
            letter = Random.Range(1, 26);
            temp.GetComponent<SpriteRenderer>().sprite = spriteSelection[letter - 1];
            temp.transform.position = new Vector3(Random.Range(-10,10), Random.Range(-3, 5), transform.position.z);
            temp.SetActive(true);
        }
        last = false;
    }

    //Destroy the Letter but first it checks if it's the last one. If so, before destroying creates another GameObject.
    private void OnTriggerEnter()
    {
        if (last == true) { 
            spawn();
        }
        Destroy(gameObject);
        //addLetterToStack();
    }
}

