using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class AttackMain : MonoBehaviour
{
	private int count;

	public GameObject prefab;

	void Start() 
	{
		//print("1");
		StartCoroutine(playGame());
	}
	

	IEnumerator playGame()
	{
		int numDots = Random.Range(5, 8);
		float lastX = 10;
		float lastY = 10;
		List<GameObject> dots = new List<GameObject>();
		for(int i = 0; i < numDots; i++)
		{
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
            dot.GetComponent<DotScript>().SetSprite(i);
			yield return new WaitForSeconds(.3f);

		}	
		
	}

}
