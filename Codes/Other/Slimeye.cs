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
//Two frames of the demon eye ai
        }
        public override void SetDefaults()
        {
        //THE MOST BOOTLEG BOSS YOU COULD EVER GET
            npc.boss = true;
            npc.width = 152;
            npc.height = 110;
            //I got eye of cthlulu sizes 
            npc.npcSlots = 5;
            npc.aiStyle = 2;
            //This is the aistyle of the demon eye, 
            npc.noTileCollide = true;
            //This is smt I changed abt the ai type so it didnt look weird
            npc.lavaImmune = true;
            music = MusicID.Boss5;
            //Muuuuuusic
            bossBag = mod.ItemType("BossBag");
         //I called my item BossBag btw, so U put urs.
            animationType = NPCID.DemonEye;
            //Simple two framer


            npc.lifeMax = 700;
            npc.damage = 24;
            npc.defense = 4;
            //some statsss

            npc.HitSound = SoundID.NPCHit1;
            npc.DeathSound = SoundID.NPCDeath1;
            // simple sounds


            npc.knockBackResist = .08f;
            //recommended 0, i did this cuz it's a pre king slime boss aka easy af

         
            aiType = NPCID.DemonEye;
            //ai type that of the demon eye
        }
        public override void ScaleExpertStats(int numPlayers, float bossLifeScale)
        {
            npc.lifeMax = (int)(npc.lifeMax * (bossLifeScale ));
            npc.damage = (int)(npc.damage * 1.3f);
            //this is necessary to scale your boss in expert / multiplayer
        }

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
//THis ordeal makes it go away when the player dies
                }         
                }

         
            if (Main.expertMode)
            //These are some experted changes
            {
                if (npc.life <= 500)
                {
                //Quote on quote second phase lol, i did jack with coding, I just raised it's defense
                    npc.defense = 6;
                }
                if (npc.life <= 9)
                {
                //Makes it so you have to do 10+ damage to kill it, this is my unique trait - prob shouldnt do this, idek what im looking at.
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
            //Reference Rat Fiesta -> Codes -> Other
            if (Main.expertMode == true)
            {
                npc.DropBossBags();
                //drops bag in expert
            }
            else
            {
            //splurs objects in non expert
                Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.GoldCoin, Main.rand.Next(2, 4), true, -1);
             

                Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("Gooeye"), Main.rand.Next(10, 20), true, -1);

                if (Main.rand.Next(1, 5) != 2)
                {
                //75% chance to drop one of the two loot
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
        //Made it so in expert, potions dont splur out, and in normal, some Bengays drop out (bengays is a potion btw)
            if (Main.expertMode == true) { potionType = 0; }
            if (Main.expertMode == false) { potionType = ModContent.ItemType<ABenGay>(); }

        }
    }
}
