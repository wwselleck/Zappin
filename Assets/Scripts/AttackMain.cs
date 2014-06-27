using UnityEngine;
using System.Collections;
using System.Collections.Generic;

/* Controls the Attack Game. Heavily referenced from the dot objects */

public class AttackMain : MonoBehaviour
{
	//Time in between each dot appearing...I think should be 0
	public float prefabDelay;

	//Dot that should be tapped/hovered/etc. next. Matches with dotNum on each dot object
	public static int currentDot = 0;

	//Number of dots for this game
	private int numDots;

	//Is the game over?
	private bool gameOver;

	//Dot prefab
	public GameObject prefab;
	public static bool dragActive = false;
	public static List<GameObject> dots = new List<GameObject>();

	void Start() 
	{
		numDots = 6; //Random.Range(5, 8);
		gameOver = false;
		PlayGame();
	}

	void Update()
	{
		if(currentDot == numDots)
		{
			gameOver = true; //you won bro!
		}
		if (Input.GetMouseButtonUp(0) && dragActive)
		{
			print("FUCK");
			dragActive = false;
			SetAllDotsInactive();
		}


	}

	void OnGUI()
	{
		if(gameOver)
		{
			Texture2D finishTexture = (Texture2D) Resources.Load("Textures/Finish", typeof(Texture2D));
			GUI.DrawTexture(new Rect(Screen.width/2 - finishTexture.width/2, 
									 Screen.height/2 - finishTexture.height/2,
									 finishTexture.width, 
									 finishTexture.height)
							, finishTexture);
		}
	}

	

	void PlayGame()
	{
		float lastX = 10;
		float lastY = 10;
		for(int i = 0; i < numDots; i++)
		{
			//yield return new WaitForSeconds(0);
			float x = Random.Range(-8f, 8f);
			float y = Random.Range(-4f, 4f);

			while((Mathf.Abs(lastX - x) < 2f) || (Mathf.Abs(lastY - y) < 2f) || Physics2D.OverlapCircle(new Vector2(x, y), 2f) != null)
			{
				x = Random.Range(-8f, 8f);
				y = Random.Range(-4f, 4f);
			}

			lastX = x;
			lastY = y;
			GameObject dot = Instantiate(prefab, new Vector3(x, y, 0f), Quaternion.identity) as GameObject;
			dot.GetComponent<DotScript>().Setup(i);
            dots.Add(dot);
		}		
	}



	void SetAllDotsInactive()
	{
		for(int i = 0; i < currentDot; i++)
		{
			dots[i].GetComponent<DotScript>().ActiveToggle();
		}
		currentDot = 0;
	}

}
