using UnityEngine;
using System.Collections;

public class DotScript : MonoBehaviour {

	private int dotNum;
	
	public void SetSprite(int num)
	{
		dotNum = num;
		GetComponent<SpriteRenderer>().sprite = (Sprite) Resources.Load("Textures/Dots/" + (dotNum + 1) + "Dot", typeof(Sprite));
		
	}

	void OnMouseDown()
	{
		if(AttackMain.currentDot == dotNum)
		{
			print("HIT");
			Destroy(gameObject);
			AttackMain.currentDot += 1;
		}
	}


}
