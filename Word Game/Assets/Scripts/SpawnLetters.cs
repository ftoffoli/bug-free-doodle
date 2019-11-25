using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;


public class SpawnLetters : MonoBehaviour
{

    public float rateSpawn;
    public List<GameObject> prefab;
    public List<GameObject> list;
    public List<GameObject> stackList;
    public float letterLife;
    public List<Sprite> spriteSelection;

    private SpriteRenderer spriteRenderer;
    private float createRateSpawn;
    private int letter;
    private bool active = true;
    private bool last = true;
    private GameObject temp;
    private GameObject word;
    public Text stack;
    private string stackString;
    private int letterPosition = 99;

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
    //In this method we get the proper Sprite that will appear
    private void OnTriggerEnter()
    {
        if (last == true) { 
            spawn();
        }
        letterPosition = int.Parse(gameObject.GetComponent<SpriteRenderer>().sprite.name.Substring(8));
        checkLenghtAndAdd();
        Destroy(gameObject);
    }

    //Add the letter that collided into the stack and check the length of it
    private void checkLenghtAndAdd()
    {
        stackString = stack.text.ToString();
        if (stackString.Length == 10)
        {
            stackString = stackString.Substring(1, stackString.Length - 1);
            stack.text = stackString;
            addLetterToStack();
        }
        else
        {
            addLetterToStack();
        }
            
    }

    //Add the letter of the collision to the letter stack
    private void addLetterToStack()
    {
        if (gameObject.GetComponent<SpriteRenderer>().sprite == spriteSelection[0])
            stack.text += "a";
        else if (gameObject.GetComponent<SpriteRenderer>().sprite == spriteSelection[1])
            stack.text += "b";
        else if (gameObject.GetComponent<SpriteRenderer>().sprite == spriteSelection[2])
            stack.text += "c";
        else if (gameObject.GetComponent<SpriteRenderer>().sprite == spriteSelection[3])
            stack.text += "d";
        else if (gameObject.GetComponent<SpriteRenderer>().sprite == spriteSelection[4])
            stack.text += "e";
        else if (gameObject.GetComponent<SpriteRenderer>().sprite == spriteSelection[5])
            stack.text += "f";
        else if (gameObject.GetComponent<SpriteRenderer>().sprite == spriteSelection[6])
            stack.text += "g";
        else if (gameObject.GetComponent<SpriteRenderer>().sprite == spriteSelection[7])
            stack.text += "h";
        else if (gameObject.GetComponent<SpriteRenderer>().sprite == spriteSelection[8])
            stack.text += "i";
        else if (gameObject.GetComponent<SpriteRenderer>().sprite == spriteSelection[9])
            stack.text += "j";
        else if (gameObject.GetComponent<SpriteRenderer>().sprite == spriteSelection[10])
            stack.text += "k";
        else if (gameObject.GetComponent<SpriteRenderer>().sprite == spriteSelection[11])
            stack.text += "l";
        else if (gameObject.GetComponent<SpriteRenderer>().sprite == spriteSelection[12])
            stack.text += "m";
        else if (gameObject.GetComponent<SpriteRenderer>().sprite == spriteSelection[13])
            stack.text += "n";
        else if (gameObject.GetComponent<SpriteRenderer>().sprite == spriteSelection[14])
            stack.text += "o";
        else if (gameObject.GetComponent<SpriteRenderer>().sprite == spriteSelection[15])
            stack.text += "p";
        else if (gameObject.GetComponent<SpriteRenderer>().sprite == spriteSelection[16])
            stack.text += "q";
        else if (gameObject.GetComponent<SpriteRenderer>().sprite == spriteSelection[17])
            stack.text += "r";
        else if (gameObject.GetComponent<SpriteRenderer>().sprite == spriteSelection[18])
            stack.text += "s";
        else if (gameObject.GetComponent<SpriteRenderer>().sprite == spriteSelection[19])
            stack.text += "t";
        else if (gameObject.GetComponent<SpriteRenderer>().sprite == spriteSelection[20])
            stack.text += "u";
        else if (gameObject.GetComponent<SpriteRenderer>().sprite == spriteSelection[21])
            stack.text += "v";
        else if (gameObject.GetComponent<SpriteRenderer>().sprite == spriteSelection[22])
            stack.text += "w";
        else if (gameObject.GetComponent<SpriteRenderer>().sprite == spriteSelection[23])
            stack.text += "x";
        else if (gameObject.GetComponent<SpriteRenderer>().sprite == spriteSelection[24])
            stack.text += "y";
        else if (gameObject.GetComponent<SpriteRenderer>().sprite == spriteSelection[25])
            stack.text += "z";
        stackToSprite(stackString.Length);
    }

    //Parei aqui
    private void stackToSprite(int position)
    {
        if (stackString.Length == 9)
        {
            for (int i = 0; i < 10; i++)
            {
                if(i!=9)
                    stackList[i].GetComponent<SpriteRenderer>().sprite = stackList[i + 1].GetComponent<SpriteRenderer>().sprite;
                else
                    stackList[9].GetComponent<SpriteRenderer>().sprite = spriteSelection[letterPosition];
            }
        }
        else
        {
            stackList[position].GetComponent<SpriteRenderer>().sprite = spriteSelection[letterPosition];
        }
    }
}

