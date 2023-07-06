Enemy Warrior = new Enemy("Warrior");

Attack Punch = new Attack("Punch", 15);
Attack Kick = new Attack("Kick", 10);
Attack Throw = new Attack("Throw", 5);

Warrior.AttackList.Add(Punch);
Warrior.AttackList.Add(Kick);
Warrior.AttackList.Add(Throw);


//getting a random attack
// for (int i = 0; i < 5; i++) 
// {
//     Warrior.RandomAttack();
// }


//loop thru the list of attacks from Attack.ToString()
for (int i = 0; i < Warrior.AttackList.Count; i++) 
{
    Console.WriteLine(Warrior.AttackList[i]);
}



