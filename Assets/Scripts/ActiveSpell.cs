using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ActiveSpell{
	
	public Spell spell;
	public int remainingTurn;
	
	public ActiveSpell (Spell spell){
		this.spell = spell;
		this.remainingTurn = spell.turn;
	}
	
	public bool effect(Creature creature){
		remainingTurn--;
		this.spell.turnEffect(creature);
		if(remainingTurn == 0)
			return false;
		else
			return true;
	}
}