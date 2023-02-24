using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextBasedRPG
{
    class Character
    {
        //player alive or dead, each character can be alive or die
        protected enum VitalStatus
        {
            Alive,
            Dead
        }
        //Character stats
        public int health;
        public int armor;
        public int xLoc;
        public int yLoc;
        public int attackDamage;
        public string name;
        protected VitalStatus vitalStatus;
        public Tile characterTile = new Tile(' ', ConsoleColor.White);

        //to switch or set if the character is alive or dead

        protected void SwitchVitalStatus(VitalStatus newVitalStatus)
        {
            vitalStatus = newVitalStatus;

            switch (vitalStatus)
            {
                case VitalStatus.Alive:
                    break;
                case VitalStatus.Dead:
                    Die();
                    break;
            }
        }
        //draws each game character
        public void Draw(MvmtCamera camera)
        {
            camera.DrawToRenderer(characterTile.tileCharacter, xLoc, yLoc);
        }

        //damage method for each game character
        public void TakeDamage(int Damage)
        {
            //spill over
            int remainingDamage = Damage - armor;
            armor = armor - Damage;
            if (armor <= 0)
            {
                //armor breaks then damage starts to take away from health
                armor = 0;
                health = health - remainingDamage;
            }
            if (health <= 0)
            {
                //die when health is 0
                SwitchVitalStatus(VitalStatus.Dead);
                Console.Beep(1000, 100);
            }
        }
        //healing method, first aid
        public void Heal(int hp)
        {
            health = health + hp;
        }
        //regen armor
        public void RegenArmor(int sp)
        {
            armor = armor + sp;
            if (armor >= 50)
            {
                //armor max 100
                armor = 50;
            }
        }
        //show on screen character death
        public void Die()
        {
            characterTile.tileColour = ConsoleColor.White;
            health = 0;
            characterTile.tileCharacter = 'X';
        }
    }
}
