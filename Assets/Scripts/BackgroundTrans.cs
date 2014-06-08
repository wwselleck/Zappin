using UnityEngine;
using System.Collections;

public class BackgroundTrans : MonoBehaviour {

	public Sprite texture1;
	public Sprite texture2;
	public float duration;
	private SpriteRenderer spriteRenderer;
	// Use this for initialization
	void Start () {
		spriteRenderer = (SpriteRenderer) GetComponent<SpriteRenderer>();
		spriteRenderer.sprite = texture1;
	}
	
	// Update is called once per frame
	void Update () {
	}

}
