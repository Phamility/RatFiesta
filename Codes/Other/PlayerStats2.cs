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
    class PlayerStats2 : ModPlayer
    {
        //------------------------------------------------------------------------------------------


        public const int Threat2Max = 1;
        public int Threat2Consumption;
        public static bool Threat2Consumed;
        public override void ResetEffects()
        {

//This is an example of one of my Mysterious idols permamnent buffs.
            player.statDefense += (Threat2Consumption * 12);
            if (Threat2Max == Threat2Consumption)
            {
                Threat2Consumed = true;
                player.AddBuff(ModContent.BuffType<Darkness>(), 2);
                //This just forces the buff onto the player if they consumed any darkness
                PlayerStats.Idolsconsumed += 1;
                //This is to keep track of how many idols uve used.
            }
            else { Threat2Consumed = false; }
            //this static bool helps decide what the Threat Analyzer should say.

        }
        public override void SyncPlayer(int toWho, int fromWho, bool newPlayer)
        {
            ModPacket packet = mod.GetPacket();

            packet.Write(Threat2Consumption);
            packet.Send(toWho, fromWho);
        }
        public override TagCompound Save()
        {
            return new TagCompound
            {
                {"Threat2Consumption", Threat2Consumption }

            };
//To be honest, I just know this is necessary for permanenet upgrades like life crystals.



        }
        public override void Load(TagCompound tag)
        {
            Threat2Consumption = tag.GetInt("Threat2Consumption");
        }
    }
    //--------------------------------------------------------------------------------------------
}
