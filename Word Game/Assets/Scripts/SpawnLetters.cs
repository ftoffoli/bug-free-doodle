using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SpawnLetters : MonoBehaviour
{

    public float rateSpawn;
    public List<GameObject> prefab;
    public List<GameObject> list;
    public int maxObjects;
    public Sprite sprite1, sprite2, sprite3, sprite4, sprite5, sprite6, sprite7, sprite8, sprite9, sprite10, sprite11,
                  sprite12, sprite13, sprite14, sprite15, sprite16, sprite17, sprite18, sprite19, sprite20, sprite21,
                  sprite22, sprite23, sprite24, sprite25, sprite26;

    private SpriteRenderer spriteRenderer;
    private int letter;
    private float createRateSpawn;
    private bool active = true;


    void Start()
    {

    }

    /*  When the timer achieves the currentRateSpawn, 
        the method spawn is called and the GameObject is setted as inactive
        Doing it, the GameObject will not be duplicated*/

    void Update()
    {
        createRateSpawn += Time.deltaTime;
        if (createRateSpawn > rateSpawn)
        {
            createRateSpawn = 0;
            if(active==true)
                spawn();
            active = false;
        }
    }


    /* Create a temp GameObject, spawn it a random position and change the 
     * sprite calling the method ChangeSprite
     * */
    private void spawn()
    {
        GameObject temp;
        list.Clear();
        temp = Instantiate(prefab[0]) as GameObject;
        list.Add(temp);
        if (temp != null)
        {
            changeSprite(temp);
            temp.transform.position = new Vector3(Random.RandomRange(-10,10), Random.RandomRange(-3, 5), transform.position.z);
            temp.SetActive(true);
        }
    }



    /* Randomize the letter and set the specific sprite for each letter
     * */
    private void changeSprite(GameObject temp)
    {

        letter = Random.Range(1, 26);
        if (letter == 1)
            temp.GetComponent<SpriteRenderer>().sprite = sprite1;
        else if (letter == 2)
            temp.GetComponent<SpriteRenderer>().sprite = sprite2;
        else if (letter == 3)
            temp.GetComponent<SpriteRenderer>().sprite = sprite3;
        else if (letter == 4)
            temp.GetComponent<SpriteRenderer>().sprite = sprite4;
        else if (letter == 5)
            temp.GetComponent<SpriteRenderer>().sprite = sprite5;
        else if (letter == 6)
            temp.GetComponent<SpriteRenderer>().sprite = sprite6;
        else if (letter == 7)
            temp.GetComponent<SpriteRenderer>().sprite = sprite7;
        else if (letter == 8)
            temp.GetComponent<SpriteRenderer>().sprite = sprite8;
        else if (letter == 9)
            temp.GetComponent<SpriteRenderer>().sprite = sprite9;
        else if (letter == 10)
            temp.GetComponent<SpriteRenderer>().sprite = sprite10;
        else if (letter == 11)
            temp.GetComponent<SpriteRenderer>().sprite = sprite11;
        else if (letter == 12)
            temp.GetComponent<SpriteRenderer>().sprite = sprite12;
        else if (letter == 13)
            temp.GetComponent<SpriteRenderer>().sprite = sprite13;
        else if (letter == 14)
            temp.GetComponent<SpriteRenderer>().sprite = sprite14;
        else if (letter == 15)
            temp.GetComponent<SpriteRenderer>().sprite = sprite15;
        else if (letter == 16)
            temp.GetComponent<SpriteRenderer>().sprite = sprite16;
        else if (letter == 17)
            temp.GetComponent<SpriteRenderer>().sprite = sprite17;
        else if (letter == 18)
            temp.GetComponent<SpriteRenderer>().sprite = sprite18;
        else if (letter == 19)
            temp.GetComponent<SpriteRenderer>().sprite = sprite19;
        else if (letter == 20)
            temp.GetComponent<SpriteRenderer>().sprite = sprite20;
        else if (letter == 21)
            temp.GetComponent<SpriteRenderer>().sprite = sprite21;
        else if (letter == 22)
            temp.GetComponent<SpriteRenderer>().sprite = sprite22;
        else if (letter == 23)
            temp.GetComponent<SpriteRenderer>().sprite = sprite23;
        else if (letter == 24)
            temp.GetComponent<SpriteRenderer>().sprite = sprite24;
        else if (letter == 25)
            temp.GetComponent<SpriteRenderer>().sprite = sprite25;
        else if (letter == 26)
            temp.GetComponent<SpriteRenderer>().sprite = sprite26;
    }


}
