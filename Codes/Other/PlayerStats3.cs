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
    class PlayerStats3 : ModPlayer
    {
        //------------------------------------------------------------------------------------------


        public const int Threat3Max = 1;
        public int Threat3Consumption;
        public static bool Threat3Consumed;
        public override void ResetEffects()
        {

            player.lifeRegen += (Threat3Consumption * 6);
            player.manaRegen += (Threat3Consumption * 6);
            player.runAcceleration *= 1.12f;
            player.maxRunSpeed *= 1.12f;
            if (Threat3Max == Threat3Consumption)
            {
                Threat3Consumed = true;
                player.AddBuff(ModContent.BuffType<Darkness>(), 2);
                PlayerStats.Idolsconsumed += 1;
            }
            else { Threat3Consumed = false; }

        }
        public override void SyncPlayer(int toWho, int fromWho, bool newPlayer)
        {
            ModPacket packet = mod.GetPacket();

            packet.Write(Threat3Consumption);
            packet.Send(toWho, fromWho);
        }
        public override TagCompound Save()
        {
            return new TagCompound
            {
                {"Threat3Consumption", Threat3Consumption }

            };




        }
        public override void Load(TagCompound tag)
        {
            Threat3Consumption = tag.GetInt("Threat3Consumption");
        }
    }
    //--------------------------------------------------------------------------------------------
}
