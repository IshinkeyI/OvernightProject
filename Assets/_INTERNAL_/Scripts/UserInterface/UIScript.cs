using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

[AddComponentMenu("")]
public class UIScript : MonoBehaviour
{
	[Header("Configuration")]
	public Players numberOfPlayers = Players.OnePlayer;

	public GameType gameType = GameType.Score;

	// If the scoreToWin is -1, the game becomes endless (no win conditions, but you could do game over)
	public int scoreToWin = 5;


	[Header("References (don't touch)")]
	//Right is used for the score in P1 games
	public Text[] numberLabels = new Text[2];
	public Text rightLabel, leftLabel;
	public Text winLabel;
	public GameObject statsPanel, gameOverPanel, winPanel;
	public Transform inventory;
	public GameObject resourceItemPrefab;


	// Internal variables to keep track of score, health, and resources, win state
	private int[] scores = new int[2];
	private int[] playersHealth = new int[2];
	private Dictionary<int, ResourceStruct> resourcesDict = new(); //holds a reference to all the resources collected, and to their UI
    private bool gameOver; //this gets changed when the game is won OR lost


	private void Start()
	{
		if (numberOfPlayers == Players.OnePlayer) return;

		if (gameType == GameType.Score)
		{
			rightLabel.text = leftLabel.text = "Score";
			numberLabels[0].text = numberLabels[1].text = "0";
			scores[0] = scores[1] = 0;
		}
		else
		{
			rightLabel.text = leftLabel.text = "Life";
		}
	}


	public void AddPoints(int playerNumber, int amount = 1)
	{
		scores[playerNumber] += amount;

		if(numberOfPlayers == Players.OnePlayer)
		{
			numberLabels[1].text = scores[playerNumber].ToString(); //with one player, the score is on the right
		}
		else
		{
			numberLabels[playerNumber].text = scores[playerNumber].ToString();
		}

		if(gameType == GameType.Score
			&& scores[playerNumber] >= scoreToWin)
		{
			GameWon(playerNumber);
		}
	}

	private void GameWon(int playerNumber)
	{
		if (gameOver) return;
		
		gameOver = true;
		winLabel.text = "Player " + ++playerNumber + " wins!";
		statsPanel.SetActive(false);
		winPanel.SetActive(true);
	}


	private void GameOver()
	{
		if (gameOver) return;
		
		gameOver = true;
		statsPanel.SetActive(false);
		gameOverPanel.SetActive(true);
	}



	public void SetHealth(int amount, int playerNumber)
	{
		playersHealth[playerNumber] = amount;
		numberLabels[playerNumber].text = playersHealth[playerNumber].ToString();
	}



	public void ChangeHealth(int change, int playerNumber)
	{
		SetHealth(playersHealth[playerNumber] + change, playerNumber);

		if(gameType != GameType.Endless
			&& playersHealth[playerNumber] <= 0)
		{
			GameOver();
		}

	}



	//Adds a resource to the dictionary, and to the UI
	public void AddResource(int resourceType, int pickedUpAmount, Sprite graphics)
	{
		if(resourcesDict.ContainsKey(resourceType))
		{
			int newAmount = resourcesDict[resourceType].amount + pickedUpAmount;
			resourcesDict[resourceType].UIItem.ShowNumber(newAmount);
			resourcesDict[resourceType].amount = newAmount;
		}
		else
		{
			UIItemScript newUIItem = Instantiate(resourceItemPrefab).GetComponent<UIItemScript>();
			newUIItem.transform.SetParent(inventory, false);

			resourcesDict.Add(resourceType, new ResourceStruct(pickedUpAmount, newUIItem));

			resourcesDict[resourceType].UIItem.ShowNumber(pickedUpAmount);
			resourcesDict[resourceType].UIItem.DisplayIcon(graphics);
		}
	}
	
	public enum Players
	{
		OnePlayer = 0,
	}

	public enum GameType
	{
		Score = 0,
		Endless
	}
}

public class ResourceStruct
{
	public int amount;
	public UIItemScript UIItem;

	public ResourceStruct(int a, UIItemScript uiRef)
	{
		amount = a;
		UIItem = uiRef;
	}
}