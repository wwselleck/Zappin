using UnityEngine;
using System.Collections;

public class DotScript : MonoBehaviour {

	public Sprite[] dotTextures = new Sprite[8];
	
	public void SetSprite(int num)
	{
		GetComponent<SpriteRenderer>().sprite = dotTextures[num];
	}
}
