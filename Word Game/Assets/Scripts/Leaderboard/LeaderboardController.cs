using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class LeaderboardController : MonoBehaviour
{
	private static LeaderboardController instance6;

	private string secretKey = "dBNqJTGHVPD"; // Edit this value and make sure it's the same as the one stored on the server
	
	string addScoreURL = "souphd.com.br/addscore.php?"; //be sure to add a ? to your url
	string addPlayerURL = "souphd.com.br/addplayer.php?";


	string highscoreURL = "souphd.com.br/display.php";
	string bedroomURL = "souphd.com.br/displaybedroom.php";
	string bathroomURL = "souphd.com.br/displaybathroom.php";
	string kitchenURL = "souphd.com.br/displaykitchen.php";
	string roomURL = "souphd.com.br/displayroom.php";

	public int id;
	public string email;
	public float score;
	public string level;
	public GameObject panel;
	public string finalMessage;
	public bool hasSaved = false;
	private bool leaderboardScene = false;

	public static LeaderboardController Instance
	{
		get { return instance6; }
	}
	void Awake()
	{

		DontDestroyOnLoad(gameObject);
		// If no Player ever existed, we are it.
		if (instance6 == null)
			instance6 = this;
		// If one already exist, it's because it came from another level.
		else if (instance6 != this)
		{
			Destroy(gameObject);
			return;
		}

	}
	void Start()
	{
		startGetScores("Geral");
		

		//
		//HSController.Instance.startGetScores ();
	}

	private void Update()
	{
		if(SceneManager.GetActiveScene().name.Equals("Leaderboard") && !leaderboardScene)
		{
			panel = GameObject.Find("Highscore Panel");
			leaderboardScene = true;
		}
		else
		{
			leaderboardScene = false;
		}
	}
	public string[] onlineHighscore;

	public void startGetScores(string level)
	{
		StartCoroutine(GetScores(level));
	}

	public void startPostScores()
	{
		StartCoroutine(PostScores());
	}

	public void startAddPlayer(string playerName, string playerEmail)
	{
		StartCoroutine(AddPlayer(playerName, playerEmail));
	}

	//set actual values before posting score
	public void updateOnlineHighscoreData(string newEmail, float newScore, string newLevel)
	{
		// uniqueID,name3 and score will get the actual value before posting score
		id = 1; //Replace this TestScript variable into your game-variables
		email = newEmail;
		score = newScore;
		level = newLevel;

		startPostScores();
	}

	public string Md5Sum(string strToEncrypt)
	{
		System.Text.UTF8Encoding ue = new System.Text.UTF8Encoding();
		byte[] bytes = ue.GetBytes(strToEncrypt);

		// encrypt bytes
		System.Security.Cryptography.MD5CryptoServiceProvider md5 = new System.Security.Cryptography.MD5CryptoServiceProvider();
		byte[] hashBytes = md5.ComputeHash(bytes);

		// Convert the encrypted bytes back to a string (base 16)
		string hashString = "";

		for (int i = 0; i < hashBytes.Length; i++)
		{
			hashString += System.Convert.ToString(hashBytes[i], 16).PadLeft(2, '0');
		}

		return hashString.PadLeft(32, '0');
	}

	// remember to use StartCoroutine when calling this function!
	IEnumerator PostScores()
	{
		//This connects to a server side php script that will add the name and score to a MySQL DB.
		// Supply it with a string representing the players name and the players score.
		string hash = Md5Sum(email + score.ToString() + level + secretKey);
		string post_url = addScoreURL + "&id=" + id + "&email=" + email + "&score=" + score + "&level=" + level + "&hash=" + hash;
		//Debug.Log ("post url " + post_url);
		// Post the URL to the site and create a download object to get the result.
		WWW hs_post = new WWW("http://" + post_url);
		yield return hs_post; // Wait until the download is done


		if (hs_post.error != null)
		{
			Debug.Log("erro no post score");
			print("There was an error posting the high score: " + hs_post.error);
		}
	}

	// Get the scores from the MySQL DB to display in a GUIText.
	// remember to use StartCoroutine when calling this function!
	public IEnumerator GetScores(string level)
	{
		string URL;
		Scrolllist.Instance.loading = true;

		#region Panel color change conditions
		if (level.Equals("Quarto"))
		{
			URL = bedroomURL;
			panel.GetComponent<Image>().color = new Color32(180, 90, 100, 255);
		}
		else if (level.Equals("Banheiro"))
		{
			URL = bathroomURL;
			panel.GetComponent<Image>().color = new Color32(74, 126, 192, 255);
		}
		else if (level.Equals("Cozinha"))
		{
			URL = kitchenURL;
			panel.GetComponent<Image>().color = new Color32(23, 149, 100, 255);
		}
		else if (level.Equals("Sala"))
		{
			URL = roomURL;
			panel.GetComponent<Image>().color = new Color32(183, 182, 94, 255);
		}
		else
		{
			URL = highscoreURL;
			//panel.GetComponent<Image>().color = new Color32(255, 255, 255, 255);
		}
#endregion

        WWW hs_get = new WWW("http://" + URL);

		yield return hs_get;

		if (hs_get.error != null)
		{
			Debug.Log("There was an error getting the high score: " + hs_get.error);
		}
		else
		{
			//Change .text into string to use Substring and Split
			string help = hs_get.text;

			//help= help.Substring(5, hs_get.text.Length-5);
			//200 is maximum length of highscore - 100 Positions (name+score)

			//onlineHighscore = help.Split(","[0]);
			onlineHighscore = help.Split(new char[] { ',', '\n' });
		}

		Scrolllist.Instance.loading = false;
		Scrolllist.Instance.getScrollEntrys();
	}

	IEnumerator AddPlayer(string playerName, string playerEmail)
	{
		//This connects to a server side php script that will add the name and score to a MySQL DB.
		// Supply it with a string representing the players name and the players score.
		string hash = Md5Sum(playerName + playerEmail + secretKey);
		//string post_url = addScoreURL + "name=" + WWW.EscapeURL(name) + "&score=" + score + "&hash=" + hash;
		string post_url = addPlayerURL + "&id=" + id + "&name=" + playerName + "&email=" + playerEmail + "&hash=" + hash;
		//Debug.Log ("post url " + post_url);
		// Post the URL to the site and create a download object to get the result.
		WWW hs_post = new WWW("http://" + post_url);
		yield return hs_post; // Wait until the download is done


		if (hs_post.text.Length > 0)
		{
			Debug.Log("There was an error posting the high score: " + hs_post.error);
			finalMessage = "Email ja cadastrado. Utilize outro email";
		}
		else
		{
			finalMessage = "Dados salvos com sucesso.";
			
		}
		hasSaved = true;
	}
}
