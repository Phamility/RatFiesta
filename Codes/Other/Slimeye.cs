using RatFiesta.Buffs;
using RatFiesta.Minions;
using RatFiesta.Items.XConsumables;

using Terraria;
using System.IO;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Utilities;
using System.Linq;
using Terraria.ModLoader.IO;
using System.Text;
using System.Threading.Tasks;
using RatFiesta.Mods;

namespace RatFiesta

{
    [AutoloadBossHead]
    public class Slimeye : ModNPC

    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Slimeye");
            Main.npcFrameCount[npc.type] = 2;

        }
        public override void SetDefaults()
        {

            npc.boss = true;
            npc.width = 152;
            npc.height = 110;
            npc.npcSlots = 5;
            npc.aiStyle = 2;
            npc.noTileCollide = true;
            npc.lavaImmune = true;
            music = MusicID.Boss5;
            bossBag = mod.ItemType("BossBag");
            //npc.lifeRegen
            animationType = NPCID.DemonEye;


            npc.lifeMax = 700;
            npc.damage = 24;
            npc.defense = 4;

            npc.HitSound = SoundID.NPCHit1;
            npc.DeathSound = SoundID.NPCDeath1;


            npc.knockBackResist = .08f;

            //npc.buffImmune[20] = true;
            aiType = NPCID.DemonEye;

        }
        public override void ScaleExpertStats(int numPlayers, float bossLifeScale)
        {
            npc.lifeMax = (int)(npc.lifeMax * (bossLifeScale ));
            npc.damage = (int)(npc.damage * 1.3f);
        }
        // public override float SpawnChance(NPCSpawnInfo spawninfo) { return SpawnCondition.OverworldDay.Chance * .12f; }
        private bool isit = true;
        public override void AI()
        {
            
            Player player = Main.player[npc.target];
          
            if (npc.target < 0 || npc.target == 255 || player.dead || !player.active)
            {
                npc.direction = 1;
                npc.velocity.Y = npc.velocity.Y - .1f;
                if(npc.timeLeft>20)
                {
                    npc.timeLeft = 20;
                    return;

                }           }

         
            if (Main.expertMode)
            {
                if (npc.life <= 500)
                {
                    npc.defense = 6;
                }
                if (npc.life <= 9)
                {
                    if (isit == true)
                    {
                        npc.life += 1;
                        isit = false;
                    }
                    else
                    {
                        isit = true;
                        npc.life += 0;
                    }
                }
            }
        }
        public override void NPCLoot()
        {
            ZaWarudo.DownedSlimeye = true;
            if (Main.expertMode == true)
            {
                npc.DropBossBags();
            }
            else
            {
                Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.GoldCoin, Main.rand.Next(2, 4), true, -1);
             

                Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("Gooeye"), Main.rand.Next(10, 20), true, -1);

                if (Main.rand.Next(1, 5) != 2)
                {
                    if (Main.rand.Next(1, 3) == 2)
                    {
                        Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("GooeyeBear"), 1, true, -1);
                    }
                    else
                    {
                        Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("GooeyeContract"), 1, true, -1);

                    }
                }

            }
        }
        public override void BossLoot(ref string name, ref int potionType)
        {
            if (Main.expertMode == true) { potionType = 0; }
            if (Main.expertMode == false) { potionType = ModContent.ItemType<ABenGay>(); }

        }
    }
}
