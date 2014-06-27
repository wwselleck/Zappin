using UnityEngine;
using System.Collections;

public class DotScript : MonoBehaviour {

	private int dotNum;
	private bool active;
	private Sprite sprite;


	void Start()
	{
		//dotNum = AttackMain.dots.Count + 1;
		active = false;
		SetSprite();
	}



	/*
	void OnMouseDown()
	{
		if(AttackMain.currentDot == dotNum)
		{
			print("HIT");
			Destroy(gameObject);
			AttackMain.currentDot += 1;
		}
	}
	*/

	void OnMouseDown()
	{
		if(!AttackMain.dragActive && dotNum == 0)
		{
			ActiveToggle();
			AttackMain.dragActive = true;
			AttackMain.currentDot++;
		}
	}


	void OnMouseOver()
	{
		if(AttackMain.dragActive)
		{
			if(AttackMain.currentDot == dotNum && dotNum != 0)
			{
				ActiveToggle();
				AttackMain.currentDot++;
			}

		}

	}

	public void ActiveToggle()
	{
		active = !active;
		SetSprite();
	}

	void SetSprite()
	{
		if(active)
		{
			sprite = (Sprite) Resources.Load("Textures/Dots/" + (dotNum + 1) + "DotActive", typeof(Sprite));
		}
		else
		{
			sprite = (Sprite) Resources.Load("Textures/Dots/" + (dotNum + 1) + "Dot", typeof(Sprite));
		}
		GetComponent<SpriteRenderer>().sprite = sprite;
	}

	public void Setup(int i)
	{
		dotNum = i;
		SetSprite();
	}


}
