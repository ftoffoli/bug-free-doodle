using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Scrolllist : MonoBehaviour {
	// Use this for initialization

	private static Scrolllist instance5;
	
	public static Scrolllist Instance
	{
		get { return instance5; }
	}
	void Awake() {
		
		//DontDestroyOnLoad (gameObject);
		// If no Player ever existed, we are it.
		if (instance5 == null)
			instance5 = this;
		// If one already exist, it's because it came from another level.
		else if (instance5 != this) {
			Destroy (gameObject);
			return;
		}
	}
//____________________________________________________________

	public GameObject ScrollEntry;
	public GameObject ScrollContain;
	public int yourPosition;
	public GameObject LoadingText;
	public bool loading = true;

	void Update () {
	
		if (!loading)
			LoadingText.SetActive (false);
		else
			LoadingText.SetActive (true);
	}

	public void getScrollEntrys()
	{
		int position = 1;
		//Destroy Objects that exists, because of a possible Call before
		foreach (Transform childTransform in ScrollContain.transform) Destroy(childTransform.gameObject);

		for (int i=0; i<LeaderboardController.Instance.onlineHighscore.Length-1; i++) {
			GameObject ScorePanel;
			ScorePanel = Instantiate (ScrollEntry) as GameObject;
			ScorePanel.transform.SetParent(ScrollContain.transform);
			//ScorePanel.transform.localScale = ScrollContain.transform.localScale;
			
			Transform ThisScoreName = ScorePanel.transform.Find ("Name");
			Text ScoreName = ThisScoreName.GetComponent<Text> ();
			//
			Transform ThisScorePoints = ScorePanel.transform.Find ("Score");
			Text ScorePoints = ThisScorePoints.GetComponent<Text> ();
			//
			Transform ThisScorePosition = ScorePanel.transform.Find ("Position");
			Text ScorePosition = ThisScorePosition.GetComponent<Text> ();

			Transform ThisScoreLevel = ScorePanel.transform.Find("Level");
			Text ScoreLevel = ThisScoreLevel.GetComponent<Text>();
			

			string helpString = "";
			ThisScorePosition.GetComponent<Text>().text = (position).ToString();
			position++;
			helpString = helpString+ LeaderboardController.Instance.onlineHighscore [i];
			i++;
			ScoreName.text = helpString;

			ScorePoints.text = FormatTime(float.Parse(LeaderboardController.Instance.onlineHighscore[i]));
			i++;
			ScoreLevel.text = LeaderboardController.Instance.onlineHighscore[i];

			ThisScoreLevel.gameObject.SetActive(false);

			if(ScoreLevel.text.Equals("Quarto"))
			{
				ScorePanel.GetComponent<RawImage>().color = new Color32(180, 90, 100, 255);
			}
			else if(ScoreLevel.text.Equals("Banheiro"))
			{
				ScorePanel.GetComponent<RawImage>().color = new Color32(74, 126, 192, 255);
			}
			else if (ScoreLevel.text.Equals("Cozinha"))
			{
				ScorePanel.GetComponent<RawImage>().color = new Color32(23, 149, 100, 255);
			}
			else if (ScoreLevel.text.Equals("Sala"))
			{
				ScorePanel.GetComponent<RawImage>().color = new Color32(183, 182, 94, 255);
			}
			else if (ScoreLevel.text.Equals("Geral"))
			{
				ScorePanel.GetComponent<RawImage>().color = new Color32(255, 255, 255, 255);
			}
		}
	}

	public string FormatTime(float currentTime)
	{
		//Formats the time to display as 00:00
		int minutes = Mathf.FloorToInt(currentTime / 60);
		int seconds = Mathf.FloorToInt(currentTime % 60);

		//Displays the time
		return minutes.ToString("00") + ":" + seconds.ToString("00");
	}
}
