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
using RatFiesta.Items.Accessories.Infinity;

namespace RatFiesta
{
    class SoulsConsumed : ModPlayer
    {
        //------------------------------------------------------------------------------------------


        public static int howmuchushouldadd;
        public int Threat1Consumption;
        
        public override void ResetEffects()
        {
            bool HasBuff = player.HasBuff(ModContent.BuffType<SMD>());
if(HasBuff == false) { SoulStone.isWearing = 0; }

            howmuchushouldadd = (Threat1Consumption * SoulStone.isWearing);
            SoulStone.display = Threat1Consumption;

         //   Main.NewTextMultiline(" " + rounded);
            if (NPC.downedMoonlord)
            {
                RealityBuff.scenario = 10;
            }
            else if (NPC.downedAncientCultist)
            {
                RealityBuff.scenario = 9;
            }
            else if (NPC.downedGolemBoss)
            {
                RealityBuff.scenario = 8;
            }

            else if (NPC.downedPlantBoss)
            {
                RealityBuff.scenario = 7;
            }
            else if (NPC.downedMechBossAny)
            {
                RealityBuff.scenario = 6;
            }

            else if (Main.hardMode)
            {
                RealityBuff.scenario = 5;

            }
            else if (NPC.downedBoss3)
            {
                RealityBuff.scenario = 4;
            }
          
            else if (NPC.downedBoss1)
            {
                RealityBuff.scenario = 3;
            }
            else if (NPC.downedSlimeKing || ZaWarudo.DownedSlimeye)
            {
                RealityBuff.scenario = 2;
            } else { RealityBuff.scenario = 1; }


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
