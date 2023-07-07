MeleeFighter TwinBlades = new MeleeFighter("Cole");
MagicCaster Magician = new MagicCaster("Dorian");
RangedFighter RangedFighter = new RangedFighter("Sera");


Attack Fireball = new Attack("Fireball", 25);
Attack LightningBolt = new Attack("Lightning Bolt", 20);
Attack StaffStrike = new Attack("Staff Strike", 10);

Attack Punch = new Attack("Punch", 20);
Attack Kick = new Attack("Kick", 15);
Attack Tackle = new Attack("Tackle", 25);

Attack Shoot = new Attack("Shoot", 20);
Attack Throw = new Attack("Knife Throw", 15);

RangedFighter.AttackList.Add(Shoot);
RangedFighter.AttackList.Add(Throw);

TwinBlades.AttackList.Add(Punch);
TwinBlades.AttackList.Add(Kick);
TwinBlades.AttackList.Add(Tackle);

Magician.AttackList.Add(Fireball);
Magician.AttackList.Add(LightningBolt);
Magician.AttackList.Add(StaffStrike);

// for (int i = 0; i < 5; i++) 
// {
//     TwinBlades.Rage(Magician);
//     Magician.Heal(Magician);
// }

// Magician.PerformAttack(TwinBlades, Fireball);
// RangedFighter.PerformAttack(Magician, Shoot);
// RangedFighter.PerformAttack(Magician, Shoot);
// TwinBlades.Rage(RangedFighter);
// Magician.Heal(Magician);
TwinBlades.PerformAttack(RangedFighter, Kick);
TwinBlades.Rage(Magician);
RangedFighter.PerformAttack(TwinBlades, Shoot);
RangedFighter.PerformAttack(TwinBlades, Shoot);
Magician.PerformAttack(TwinBlades, Fireball);
Magician.Heal(RangedFighter);
Magician.Heal(Magician);
