using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[System.Serializable]
public class ComboSpell : Spell {

	public List<string> components = new List<string>();

	public virtual bool requires(Queue<Spell> spells){
		return false;
	}
}
