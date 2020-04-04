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

    public GameObject gameManager;
    private ObjectsController objectsControllerScript;

    /*
     * Posicao 0 - 4 ->vogais. 
     * Posição 5-6 -> S, R, N, D, M. 
     * Posição 7-8 -> T, C, L, P, V, G, H, Q, B, F, J
     * Posição 9 -> Z, X, K, W*/
    private int[] weight = { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
    private int[] group1 = { 0, 4, 8, 14, 20 };
    private int[] group2 = { 3, 12, 13, 17, 18 };
    private int[] group3 = { 1, 2, 5, 6, 7, 9, 11, 15, 16, 19, 21 };
    private int[] group4 = { 10, 22, 23, 24, 25 };
    private int tempWeight;

    void Start()
    {
        objectsControllerScript = gameManager.GetComponent<ObjectsController>();
    }

    /*  When the timer achieves the currentRateSpawn, 
        the method spawn is called and the GameObject is setted as inactive
        Doing it, the GameObject will not be duplicated*/
    void Update()
    {
        createRateSpawn += Time.deltaTime;
        if(name=="letter")
            Destroy(gameObject, letterLife);
        if (createRateSpawn > rateSpawn && objectsControllerScript.memorized)
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
     * here is where we give importance to one group of words
        * */
    private void spawn()
    { 
        temp = Instantiate(prefab[0]) as GameObject;
        temp.name = "letter";
        if (temp != null)
        {
            tempWeight = Random.Range(0, 10);
            if (tempWeight >= 0 && tempWeight <= 4)
            {
                tempWeight = Random.Range(0,5);
                letter = group1[tempWeight];
            }
            else if (tempWeight == 5 || tempWeight == 6 || tempWeight == 7)
            {
                tempWeight = Random.Range(0, 5);
                letter = group2[tempWeight];
            }
            else if (tempWeight == 8 || tempWeight == 9)
            {
                tempWeight = Random.Range(0, 11);
                letter = group3[tempWeight];
            }
            else if (tempWeight == 10)
            {
                tempWeight = Random.Range(0, 5);
                letter = group4[tempWeight];
            }
            temp.GetComponent<SpriteRenderer>().sprite = spriteSelection[letter];
            temp.transform.position = new Vector3(Random.Range(-8, 8), Random.Range(-3, 4.3f), transform.position.z);
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

    public void updateStack()
    {
        char[] newStackArray = stack.text.ToCharArray();

        //Clear Sprites from stack list
        for (int counter = 0; counter < stackList.Count; counter++)
        {
            stackList[counter].GetComponent<SpriteRenderer>().sprite = null;
        }

        for (int counter = 9; counter >= (10 - newStackArray.Length); counter--)
        {
            for (int inCounter = newStackArray.Length - 1; inCounter >= 0; inCounter--)
            {
                if (newStackArray[inCounter] != ' ')
                {
                    if (newStackArray[inCounter].ToString() == "a")
                    {
                        stackList[counter].GetComponent<SpriteRenderer>().sprite = spriteSelection[0];
                        newStackArray[inCounter] = ' ';
                        break;
                    }
                    else if (newStackArray[inCounter].ToString() == "b")
                    {
                        stackList[counter].GetComponent<SpriteRenderer>().sprite = spriteSelection[1];
                        newStackArray[inCounter] = ' ';
                        break;
                    }
                    else if (newStackArray[inCounter].ToString() == "c")
                    {
                        stackList[counter].GetComponent<SpriteRenderer>().sprite = spriteSelection[2];
                        newStackArray[inCounter] = ' ';
                        break;
                    }
                    else if (newStackArray[inCounter].ToString() == "d")
                    {
                        stackList[counter].GetComponent<SpriteRenderer>().sprite = spriteSelection[3];
                        newStackArray[inCounter] = ' ';
                        break;
                    }
                    else if (newStackArray[inCounter].ToString() == "e")
                    {
                        stackList[counter].GetComponent<SpriteRenderer>().sprite = spriteSelection[4];
                        newStackArray[inCounter] = ' ';
                        break;
                    }
                    else if (newStackArray[inCounter].ToString() == "f")
                    {
                        stackList[counter].GetComponent<SpriteRenderer>().sprite = spriteSelection[5];
                        newStackArray[inCounter] = ' ';
                        break;
                    }
                    else if (newStackArray[inCounter].ToString() == "g")
                    {
                        stackList[counter].GetComponent<SpriteRenderer>().sprite = spriteSelection[6];
                        newStackArray[inCounter] = ' ';
                        break;
                    }
                    else if (newStackArray[inCounter].ToString() == "h")
                    {
                        stackList[counter].GetComponent<SpriteRenderer>().sprite = spriteSelection[7];
                        newStackArray[inCounter] = ' ';
                        break;
                    }
                    else if (newStackArray[inCounter].ToString() == "i")
                    {
                        stackList[counter].GetComponent<SpriteRenderer>().sprite = spriteSelection[8];
                        newStackArray[inCounter] = ' ';
                        break;
                    }
                    else if (newStackArray[inCounter].ToString() == "j")
                    {
                        stackList[counter].GetComponent<SpriteRenderer>().sprite = spriteSelection[9];
                        newStackArray[inCounter] = ' ';
                        break;
                    }
                    else if (newStackArray[inCounter].ToString() == "k")
                    {
                        stackList[counter].GetComponent<SpriteRenderer>().sprite = spriteSelection[10];
                        newStackArray[inCounter] = ' ';
                        break;
                    }
                    else if (newStackArray[inCounter].ToString() == "l")
                    {
                        stackList[counter].GetComponent<SpriteRenderer>().sprite = spriteSelection[11];
                        newStackArray[inCounter] = ' ';
                        break;
                    }
                    else if (newStackArray[inCounter].ToString() == "m")
                    {
                        stackList[counter].GetComponent<SpriteRenderer>().sprite = spriteSelection[12];
                        newStackArray[inCounter] = ' ';
                        break;
                    }
                    else if (newStackArray[inCounter].ToString() == "n")
                    {
                        stackList[counter].GetComponent<SpriteRenderer>().sprite = spriteSelection[13];
                        newStackArray[inCounter] = ' ';
                        break;
                    }
                    else if (newStackArray[inCounter].ToString() == "o")
                    {
                        stackList[counter].GetComponent<SpriteRenderer>().sprite = spriteSelection[14];
                        newStackArray[inCounter] = ' ';
                        break;
                    }
                    else if (newStackArray[inCounter].ToString() == "p")
                    {
                        stackList[counter].GetComponent<SpriteRenderer>().sprite = spriteSelection[15];
                        newStackArray[inCounter] = ' ';
                        break;
                    }
                    else if (newStackArray[inCounter].ToString() == "q")
                    {
                        stackList[counter].GetComponent<SpriteRenderer>().sprite = spriteSelection[16];
                        newStackArray[inCounter] = ' ';
                        break;
                    }
                    else if (newStackArray[inCounter].ToString() == "r")
                    {
                        stackList[counter].GetComponent<SpriteRenderer>().sprite = spriteSelection[17];
                        newStackArray[inCounter] = ' ';
                        break;
                    }
                    else if (newStackArray[inCounter].ToString() == "s")
                    {
                        stackList[counter].GetComponent<SpriteRenderer>().sprite = spriteSelection[18];
                        newStackArray[inCounter] = ' ';
                        break;
                    }
                    else if (newStackArray[inCounter].ToString() == "t")
                    {
                        stackList[counter].GetComponent<SpriteRenderer>().sprite = spriteSelection[19];
                        newStackArray[inCounter] = ' ';
                        break;
                    }
                    else if (newStackArray[inCounter].ToString() == "u")
                    {
                        stackList[counter].GetComponent<SpriteRenderer>().sprite = spriteSelection[20];
                        newStackArray[inCounter] = ' ';
                        break;
                    }
                    else if (newStackArray[inCounter].ToString() == "v")
                    {
                        stackList[counter].GetComponent<SpriteRenderer>().sprite = spriteSelection[21];
                        newStackArray[inCounter] = ' ';
                        break;
                    }
                    else if (newStackArray[inCounter].ToString() == "x")
                    {
                        stackList[counter].GetComponent<SpriteRenderer>().sprite = spriteSelection[22];
                        newStackArray[inCounter] = ' ';
                        break;
                    }
                    else if (newStackArray[inCounter].ToString() == "w")
                    {
                        stackList[counter].GetComponent<SpriteRenderer>().sprite = spriteSelection[23];
                        newStackArray[inCounter] = ' ';
                        break;
                    }
                    else if (newStackArray[inCounter].ToString() == "y")
                    {
                        stackList[counter].GetComponent<SpriteRenderer>().sprite = spriteSelection[24];
                        newStackArray[inCounter] = ' ';
                        break;
                    }
                    else if (newStackArray[inCounter].ToString() == "z")
                    {
                        stackList[counter].GetComponent<SpriteRenderer>().sprite = spriteSelection[25];
                        newStackArray[inCounter] = ' ';
                        break;
                    }

                    
                }
            }
        }
    }

    //Update the Boxes with the letter
    private void stackToSprite(int position)
    {
        stackList[0].GetComponent<SpriteRenderer>().sprite = stackList[1].GetComponent<SpriteRenderer>().sprite;
        stackList[1].GetComponent<SpriteRenderer>().sprite = stackList[2].GetComponent<SpriteRenderer>().sprite;
        stackList[2].GetComponent<SpriteRenderer>().sprite = stackList[3].GetComponent<SpriteRenderer>().sprite;
        stackList[3].GetComponent<SpriteRenderer>().sprite = stackList[4].GetComponent<SpriteRenderer>().sprite;
        stackList[4].GetComponent<SpriteRenderer>().sprite = stackList[5].GetComponent<SpriteRenderer>().sprite;
        stackList[5].GetComponent<SpriteRenderer>().sprite = stackList[6].GetComponent<SpriteRenderer>().sprite;
        stackList[6].GetComponent<SpriteRenderer>().sprite = stackList[7].GetComponent<SpriteRenderer>().sprite;
        stackList[7].GetComponent<SpriteRenderer>().sprite = stackList[8].GetComponent<SpriteRenderer>().sprite;
        stackList[8].GetComponent<SpriteRenderer>().sprite = stackList[9].GetComponent<SpriteRenderer>().sprite;
        stackList[9].GetComponent<SpriteRenderer>().sprite = spriteSelection[letterPosition];
    }
}

