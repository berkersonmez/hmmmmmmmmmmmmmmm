using UnityEngine;
using System.Collections;

public class TownButton : MonoBehaviour {
	
	private tk2dUIItem uiItem;
	
	void Start() {
		uiItem = GetComponent<tk2dUIItem>();
		uiItem.OnClick += OnClick;
	}

	void OnClick() {
		if (transform.name == "MapButton")
			TownMenu.instance.mapWindow();
		else if (transform.name == "BackButton")
			TownMenu.instance.menuWindow();
	}
}