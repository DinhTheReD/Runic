using Terraria;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;



namespace Runic.Content.Damageclass
{

    public class RunicDamage : DamageClass
    {



        public static Color DamageColor = new(0, 0, 225); // look at the damage code in AQ added to see if would do anything







        public override StatInheritanceData GetModifierInheritance(DamageClass damageClass)
        {


            // i am unsure if this is working the way i think it is
            






            if (damageClass == DamageClass.Melee)
                return  StatInheritanceData.Full;

            return new StatInheritanceData(
                    damageInheritance: 0.75f,
                    critChanceInheritance: 1f,
                    attackSpeedInheritance: 1f,
                    armorPenInheritance: 1f,
                    knockbackInheritance: 1f
                );



            


        }

        public override bool GetEffectInheritance(DamageClass damageClass)
        {
            
            if (damageClass == DamageClass.Melee)
                return true;
            
            return false;
        }


        public override void SetDefaultStats(Player player)
        {
            
            player.GetDamage<RunicDamage>() += 0; // i think this gives the damage type a baseline instead of just taking meeles
            
        }


    }
}