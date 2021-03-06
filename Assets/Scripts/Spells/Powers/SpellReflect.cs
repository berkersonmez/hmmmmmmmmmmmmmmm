using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[System.Serializable]
public class SpellReflect : Power {
	
	public SpellReflect(){
		name = "Spell Reflect";
		idName = "SpellReflect";
		effectOn = "enemy";
		totalCoolDown = -1;
		mana = 0;
		type = "fire";
		active = true;
		level = 1;
		spriteName = "avatar_spell_5";
	}
	
	public override bool react(Spell castedSpell, string effectOn, ref string combatTextExtra){
		if(effectOn != this.effectOn)
			return false;
		if(castedSpell.isOneTick == false){
			this.active = false;
			//We are doing this to get castedSpell's not edited version
			castedSpell = castedSpell.owner.getSpell(castedSpell.idName,castedSpell.level);
			castedSpell.cast(DungeonController.instance.battle, castedSpell.owner, castedSpell.owner, 0);
			this.currentCoolDown = this.totalCoolDown;
			//TODO: PRINT "REFLECTED" ON TARGET
			return true;
		}
		return false;
	}
	
	public override void setTooltipText() {
		// Tooltip text for spell.
		// Coloring: ^CRRGGBBAA*text*
		
		tooltipText = "^C7ED8E6ff" + name + "\n";
		tooltipText += "^CffffffffType: " + type + "\n\n";
		
		tooltipText += "Reflects next spell cast on you.\n";
	}
	
}