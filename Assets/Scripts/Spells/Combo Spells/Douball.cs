using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Douball : ComboSpell {
	
	public Douball(){
		name = "Douball";
		damage = 0;
		mana = 0;
		type = "nature";
		level = 1;
	}
	
	public override bool cast(Battle battle, Creature caster, Creature target){
		string combatTextExtra = "";
		Spell fireBall = caster.getSpell("FireBall",1);
		if(fireBall == null)
			return false;
		int currentDamage = (fireBall.damage + caster.spellPower - target.armor) / 4;

		currentDamage = applyCritical(caster, currentDamage);

		target.decreaseHp(caster, currentDamage);
		// Combat text
		int placement = target.isPlayer ? (int)CombatTextController.Placement.PLAYER : (int)CombatTextController.Placement.CREATURE;
		CombatTextController.instance.deployText(name, currentDamage.ToString() + combatTextExtra, placement, Color.red);
		return true;
	}

	public override bool requires(Queue<Spell> castedSpells){
		int fire_ball_count = 0;
		foreach(Spell spell in castedSpells){
			if(spell.name == "FireBall")
				fire_ball_count++;
		}
		if(fire_ball_count >= 2)
			return true;
		return false;
	}

	public override void setTooltipText() {
		// Tooltip text for spell.
		// Coloring: ^CRRGGBBAA*text*
		Creature caster = owner;
		Spell fireBall = caster.getSpell("FireBall",1);
		if(fireBall == null)
			return;
		int currentDamage = (fireBall.damage + caster.spellPower) / 4;

		tooltipText = "^C7ED8E6ff" + name + "\n";
		tooltipText += "^CffffffffType: " + type + "\n";
		tooltipText += "Combo: Fireball + Fireball\n\n";
		tooltipText += "Inflicts " + currentDamage + " damage to enemy.\n";
	}
	
}