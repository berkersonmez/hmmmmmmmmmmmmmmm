using UnityEngine;
using System.Collections;

public class TownButton : MonoBehaviour {
	
	private tk2dUIItem uiItem;
	
	void Start() {
		uiItem = GetComponent<tk2dUIItem>();
		uiItem.OnClick += OnClick;
	}

	void OnClick() {
		if (transform.name == "MapButton") {
			TownMenu.instance.mapWindow ();
			TownController.instance.updateQuestsGUI();
		}
		else if (transform.name == "BackButton")
			TownMenu.instance.menuWindow();
		else if (transform.name == "InventoryButton")
			TownMenu.instance.inventoryWindow();
		else if (transform.name == "SpellsButton")
			TownMenu.instance.spellsWindow();
		else if (transform.name == "StatsButton") {
			TownMenu.instance.statsWindow();
			StatsController.instance.updateStats();
		} else if (transform.name == "PowersButton")
			TownMenu.instance.powersWindow();
		else if (transform.name == "QuestsButton")
			TownMenu.instance.questsWindow();
		else if (transform.name == "CharacterMenuButton")
			TownMenu.instance.characterMenuWindow();
		else if (transform.name == "TalentsButton") {
			TownController.instance.updateTalentGUI();
			TownMenu.instance.talentsWindow();
		} else if (transform.name == "Right Map") {
			TownMenu.instance.mapWindowRight();
		} else if (transform.name == "Left Map") {
			TownMenu.instance.mapWindowLeft();
		} else if (transform.name == "ShopButton") {
			StoreManager.instance.openStore();
		}
	}
}
