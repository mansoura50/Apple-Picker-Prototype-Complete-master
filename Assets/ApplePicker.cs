using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ApplePicker : MonoBehaviour {
	[Header("Set in Inspector")]
	public GameObject basketPrefab;
	public int numBaskets = 3;
	public float basketBottomY = -14f;
	public float basketSpacingY = 2f;
	//stores basket pieces
	public List<GameObject> basketList;

	// Use this for initialization
	void Start () {
		basketList = new List<GameObject> ();
		for (int i = 0; i < numBaskets; i++) {
			GameObject tBasketGO = Instantiate<GameObject>
				(basketPrefab);	
			Vector3 pos = Vector3.zero;
			pos.y = basketBottomY + (basketSpacingY * i);
			tBasketGO.transform.position = pos;
			basketList.Add (tBasketGO); //build a list of baskets
		}
	}

	public void AppleDestroyed() {
		//get a list of all apples on screen
		GameObject[] tAppleArray = GameObject.FindGameObjectsWithTag ("Apple");
		foreach (GameObject tGO in tAppleArray) {
			Destroy (tGO);
		}

		//gets rid of basket
		int basketIndex = basketList.Count-1; //get the index of last basket
		GameObject tBasketGO = basketList[basketIndex];
		basketList.RemoveAt (basketIndex);
		Destroy (tBasketGO);

		//when we run out of baskets
		if (basketList.Count == 0) {
			SceneManager.LoadScene ("_Scene_0");
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}

}
