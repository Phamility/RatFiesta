using RatFiesta.Buffs;
using RatFiesta.Minions;
using System;
using Terraria;
using System.IO;
using Terraria.ID;
using Terraria.DataStructures;
using Terraria.ModLoader;
using Terraria.Utilities;
using System.Linq;
using Terraria.ModLoader.IO;
using System.Text;
using System.Threading.Tasks;
using RatFiesta.Mods;
using RatFiesta.Items.XConsumables;

namespace RatFiesta
{
    class PlayerStats1 : ModPlayer
    {
        //------------------------------------------------------------------------------------------

       
        public const int Threat1Max = 1;
        public int Threat1Consumption;
        public static bool Threat1Consumed;
        public override void ResetEffects()
        {
          
            player.statLifeMax2 += (Threat1Consumption * 30);
            player.statManaMax2 += (Threat1Consumption * 30);
            if (Threat1Max == Threat1Consumption) { Threat1Consumed = true;
                player.AddBuff(ModContent.BuffType<Darkness>(), 2);
                PlayerStats.Idolsconsumed += 1;
            } else { Threat1Consumed = false; }

        }
        public override void SyncPlayer(int toWho, int fromWho, bool newPlayer)
        {
            ModPacket packet = mod.GetPacket();
         
             packet.Write(Threat1Consumption);
            packet.Send(toWho, fromWho);
        }
        public override TagCompound Save()
        {
            return new TagCompound
            {
                {"Threat1Consumption", Threat1Consumption }

            };




        }
        public override void Load(TagCompound tag)
        {
            Threat1Consumption = tag.GetInt("Threat1Consumption");
        }
    }
    //--------------------------------------------------------------------------------------------
}
