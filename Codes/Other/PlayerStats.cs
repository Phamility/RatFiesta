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
    class PlayerStats : ModPlayer
    {
        //------------------------------------------------------------------------------------------
        public static int Idolsconsumed;
        public const int maxCelestial3Consumption = 1;
        public int usedCelestial3Consumption;
        public static bool celestialconsumed;
     
        public override void ResetEffects()
        {
            Idolsconsumed = 0;
            player.maxMinions += usedCelestial3Consumption;
            if(usedCelestial3Consumption == maxCelestial3Consumption) { celestialconsumed = true; 
                player.AddBuff(ModContent.BuffType<Darkness>(), 2);
                Idolsconsumed += 1;
            } else { celestialconsumed = false; }
        
        }
        public override void SyncPlayer(int toWho, int fromWho, bool newPlayer)
        {
            ModPacket packet = mod.GetPacket();
            packet.Write(usedCelestial3Consumption);
         
            packet.Send(toWho, fromWho);
        }
        public override TagCompound Save()
        {
            return new TagCompound
            {
                {"usedCelestial3Consumption", usedCelestial3Consumption }

            };

           
           

        }
        public override void Load(TagCompound tag)
        {
            usedCelestial3Consumption = tag.GetInt("usedCelestial3Consumption");
        }
    }
    //--------------------------------------------------------------------------------------------
}
