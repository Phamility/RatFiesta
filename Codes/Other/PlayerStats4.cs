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
    class PlayerStats4 : ModPlayer
    {
        //------------------------------------------------------------------------------------------


        public const int Threat4Max = 1;
        public int Threat4Consumption;
        public static bool Threat4Consumed;
        public override void ResetEffects()
        {

            player.allDamage += (Threat4Consumption * .05f);
            if (Threat4Max == Threat4Consumption)
            {
                Threat4Consumed = true;
                player.AddBuff(ModContent.BuffType<Darkness>(), 2);
                PlayerStats.Idolsconsumed += 1;
            }
            else { Threat4Consumed = false; }

        }
        public override void SyncPlayer(int toWho, int fromWho, bool newPlayer)
        {
            ModPacket packet = mod.GetPacket();

            packet.Write(Threat4Consumption);
            packet.Send(toWho, fromWho);
        }
        public override TagCompound Save()
        {
            return new TagCompound
            {
                {"Threat4Consumption", Threat4Consumption }

            };




        }
        public override void Load(TagCompound tag)
        {
            Threat4Consumption = tag.GetInt("Threat4Consumption");
        }
    }
    //--------------------------------------------------------------------------------------------
}
