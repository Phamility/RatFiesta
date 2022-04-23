
using Microsoft.Xna.Framework;
using RatFiesta.Buffs;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using RatFiesta.ZArmors;
using RatFiesta.Items.Accessories.Infinity;


namespace RatFiesta.Modifications
{
    public class ModGlobalNPC : GlobalNPC
    {
       
            
           
    public override void SetupShop(int type, Chest shop, ref int nextSlot)
        {
            if (type == NPCID.Merchant)
            {
                
                shop.item[nextSlot].SetDefaults(ItemID.GoblinBattleStandard);
                shop.item[nextSlot].shopCustomPrice = 50000;
 //shop.item[nextSlot].SetDefaults(ModContent.ItemType<CarKey>());
                nextSlot++;
            }
            if (type == NPCID.WitchDoctor)
            {
                shop.item[nextSlot].SetDefaults(ItemID.SummoningPotion);
                shop.item[nextSlot].shopCustomPrice = 5000;
                //shop.item[nextSlot].SetDefaults(ModContent.ItemType<CarKey>());
                nextSlot++;
            }
            if (type == NPCID.Wizard && Main.hardMode == true)
            {

                shop.item[nextSlot].SetDefaults(ItemID.TruffleWorm);
                shop.item[nextSlot].shopCustomPrice = 1000000;
                //shop.item[nextSlot].SetDefaults(ModContent.ItemType<CarKey>());
                nextSlot++;
            }
            if (type == NPCID.Clothier)
            {

                shop.item[nextSlot].SetDefaults(ModContent.ItemType<VJustinsShades>());
                shop.item[nextSlot].shopCustomPrice = 5000000;
                //shop.item[nextSlot].SetDefaults(ModContent.ItemType<CarKey>());
                nextSlot++;
                shop.item[nextSlot].SetDefaults(ModContent.ItemType<VincentsCap>());
                shop.item[nextSlot].shopCustomPrice = 5000000;
                //shop.item[nextSlot].SetDefaults(ModContent.ItemType<CarKey>());
                nextSlot++;
                shop.item[nextSlot].SetDefaults(ModContent.ItemType<VPetersBall>());
                shop.item[nextSlot].shopCustomPrice = 5000000;
                //shop.item[nextSlot].SetDefaults(ModContent.ItemType<CarKey>());
                nextSlot++;
                shop.item[nextSlot].SetDefaults(ModContent.ItemType<VSenku>());
                shop.item[nextSlot].shopCustomPrice = 5000000;
                //shop.item[nextSlot].SetDefaults(ModContent.ItemType<CarKey>());
                nextSlot++;
                shop.item[nextSlot].SetDefaults(ModContent.ItemType<VTempleLED>());
                shop.item[nextSlot].shopCustomPrice = 5000000;
                //shop.item[nextSlot].SetDefaults(ModContent.ItemType<CarKey>());
                nextSlot++;
                shop.item[nextSlot].SetDefaults(ModContent.ItemType<VVInosuke>());
                shop.item[nextSlot].shopCustomPrice = 5000000;
                //shop.item[nextSlot].SetDefaults(ModContent.ItemType<CarKey>());
                nextSlot++;
            }
        }
      
        public override void NPCLoot(NPC npc)
        {
            if(npc.type == NPCID.Harpy)
            {
                if(Main.rand.Next(1,101) <= 5)
                {
                    Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("SkyMaiden"), 1, false, -1);

                }
            }
       if(npc.type == NPCID.Skeleton || npc.type == NPCID.AngryBones || npc.type == NPCID.AngryBonesBig || npc.type == NPCID.AngryBonesBigHelmet || npc.type == NPCID.AngryBonesBigMuscle || npc.type == NPCID.BigBoned || npc.type == NPCID.ShortBones)
            {
                if (Main.rand.Next(1, 101) <= 2)
                {
                    Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("ADrainBow2"), 1, false, -1);

                }
            }
            
                if (SoulStone.isWearing == 1)
                {
                SMD.rollsminus1--;
                }

            
            if (Main.expertMode == true)
            {
                if (Main.rand.Next(1, 666) == 2)
                {
                    Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("MaidenWeapon"), 1, true, -1);

                }
            }
            else
            {
                if (Main.rand.Next(1, 777) == 2)
                {
                    Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("MaidenWeapon"), 1, true, -1);

                }
            }
            if (Main.rand.Next(1, 666) == 2)
            {
                if(Main.rand.Next(1,7) == 2)
                {
                    Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("VincentsCap"), 1, true, -1);
                }
                else if (Main.rand.Next(1, 6) == 2)
                {
                    Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("VTempleLED"), 1, true, -1);
                }
                else if (Main.rand.Next(1, 5) == 2)
                {
                    Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("VSenku"), 1, true, -1);
                }
                else if (Main.rand.Next(1, 4) == 2)
                {
                    Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("VPetersBall"), 1, true, -1);
                }
                else if (Main.rand.Next(1, 3) == 2)
                {
                    Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("VVInosuke"), 1, true, -1);
                }
                else 
                {
                    Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("VJustinsShades"), 1, true, -1);
                }
              
            }

            if (Main.hardMode == false)
            {
                if (Main.rand.Next(1, 151) == 2)
                {
                    Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("ABenGay"), (Main.rand.Next(6, 15)), true, -1);
                }
            }
            else
            {
                if (Main.rand.Next(1, 251) == 2)
                {
                    if (RealityBuff.scenario < 10)
                    {
                        Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("AAHERO"), (Main.rand.Next(2, 5)), true, -1);
                    }
                    else
                    {
                        Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("AAAPre"), (Main.rand.Next(1, 4)), true, -1);

                    }
                }
            }
            if (npc.type == NPCID.SkeletronHead)
            {
                if (SoulStone.isWearing == 1)
                {
                    SMD.rollsminus1-= 10;
                }
                //    if ( Main.rand.Next(X) = (Y))
                //    if (Main.rand.Next(2) = (1))//item rarity
                // {
                if (Main.expertMode) { }
                else
                {
                    Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("Threat2"), 1, true, -1);

                    Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("BoneHandWeapon"), 1, false, -1);
                    if (Main.rand.Next(1, 4) != 2)
                    {
                        Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("SigilOfTheDungeon"), 1, false, -1);

                    }
                    if (Main.rand.Next(1, 101) <= 20)
                    {
                        Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("ADrainBow2"), 1, false, -1);

                    }
                    // }
                }
            }
          
            if (npc.type == NPCID.Everscream)
            {
               
                //    if ( Main.rand.Next(X) = (Y))
                //    if (Main.rand.Next(2) = (1))//item rarity
                // {
                if (Main.expertMode) {
                    if (Main.rand.Next(1, 9) == 2)
                    {
                        Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("SnowdinScroll"), 1, true, -1);
                    }
                }
                else
                {
                    if (Main.rand.Next(1, 11) == 2)
                    {
                        Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("SnowdinScroll"), 1, true, -1);
                    }
                    // }
                }
            }
            //   if (npc.type == NPCID.)
            //   if (npc.type == NPCID.)
            if (npc.type == NPCID.CultistBoss)
            {
                if (SoulStone.isWearing == 1)
                {
                    SMD.rollsminus1 -= 10;
                }
                //    if ( Main.rand.Next(X) = (Y))
                //    if (Main.rand.Next(2) = (1))//item rarity
                // {


                Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("PietyFrag"), 1, true, -1);

                Item.NewItem((int)npc.position.X - 35, (int)npc.position.Y -35, npc.width, npc.height, mod.ItemType("PietyFrag"), 1, true, -1);

                if (Main.rand.Next(1, 5) == 2)
                {
                    Item.NewItem((int)npc.position.X + 32, (int)npc.position.Y - 32, npc.width, npc.height, mod.ItemType("PietyFrag"), 1, true, -1);

                }
                if (Main.rand.Next(1, 7) == 2)
                {
                    Item.NewItem((int)npc.position.X - 32, (int)npc.position.Y + 35, npc.width, npc.height, mod.ItemType("PietyFrag"), 1, true, -1);

                }
                // }

            }
            if (npc.type == NPCID.DukeFishron)
            {
                if (SoulStone.isWearing == 1)
                {
                    SMD.rollsminus1 -= 10;
                }
                //    if ( Main.rand.Next(X) = (Y))
                //    if (Main.rand.Next(2) = (1))//item rarity
                // {

                if (Main.expertMode) { }
                else
                {
                    if (Main.rand.Next(1, 3) == 2)
                    {
                        Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("FishronFin"), 1, true, -1);
                    }
                    if (Main.rand.Next(1, 4) != 2)
                    {
                        Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("SigilOfTheBeach"), 1, false, -1);

                    }
                }
                // }

            }

            //  ----------------------------------------------------------------
            if (npc.type == NPCID.Golem)
            {
                if (SoulStone.isWearing == 1)
                {
                    SMD.rollsminus1 -= 10;
                }
                //    if ( Main.rand.Next(X) = (Y))
                //    if (Main.rand.Next(2) = (1))//item rarity
                // {

                if (Main.expertMode) { }
                else
                {
                    if (Main.rand.Next(1, 4) == 2)
                    {
                        Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("ZGolemsContract"), 1, true, -1);
                    }
                    if (Main.rand.Next(1, 11) == 2)
                    {
                        Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("ODefense"), 1, true, -1);
                    }
                }
                // }

            }
            if(npc.type == NPCID.KingSlime)
            {
                if (SoulStone.isWearing == 1)
                {
                    SMD.rollsminus1 -= 10;
                }
            }
            //  ----------------------------------------------------------------
            if (npc.type == NPCID.MoonLordCore)
            {
                if (SoulStone.isWearing == 1)
                {
                    SMD.rollsminus1 -= 10;
                }
                //    if ( Main.rand.Next(X) = (Y))
                //    if (Main.rand.Next(2) = (1))//item rarity
                // {
                if (Main.expertMode) { }
                else
                {
                    // }
                }
            }
            //   if (npc.type == NPCID.)

            //  ----------------------------------------------------------------

            if (npc.boss && Array.IndexOf(new int[] { NPCID.Spazmatism, NPCID.Retinazer, }, npc.type) > -1)

            {
                if (SoulStone.isWearing == 1)
                {
                    SMD.rollsminus1 -= 10;
                }
                //    if ( Main.rand.Next(X) = (Y))
                //    if (Main.rand.Next(2) = (1))//item rarity
                // {
                if (Main.expertMode) { }
                else
                {
                    if (Main.rand.Next(1, 4) != 2)
                    {
                        Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("SigilOfSight"), 1, true, -1);
                        // }
                    }
                }
            }
            if (npc.boss && Array.IndexOf(new int[] { NPCID.EaterofWorldsBody, NPCID.EaterofWorldsHead, NPCID.EaterofWorldsTail }, npc.type) > -1)
            {
                if (SoulStone.isWearing == 1)
                {
                    SMD.rollsminus1 -= 10;
                }
                //    if ( Main.rand.Next(X) = (Y))
                //    if (Main.rand.Next(2) = (1))//item rarity
                // {
                if (Main.expertMode) { }
                else
                {
                    if (Main.rand.Next(1, 4) != 2)
                    {
                        Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("SigilOfTheCursed"), 1, true, -1);
                        // }
                    }
                }
            }


            //   if (npc.type == NPCID.)

            //  ----------------------------------------------------------------




            if (npc.type == NPCID.TheDestroyer)
            {
                if (SoulStone.isWearing == 1)
                {
                    SMD.rollsminus1 -= 10;
                }
                if (Main.expertMode) { }
                else
                {
                    //    if ( Main.rand.Next(X) = (Y))
                    //    if (Main.rand.Next(2) = (1))//item rarity
                    // {
                    if (Main.rand.Next(1, 4) != 2)
                    {
                        Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("SigilOfMight"), 1, true, -1);
                        // }
                    }
                }
            }
            //  ----------------------------------------------------------------

            if (npc.type == NPCID.SkeletronPrime)
            {
                if (SoulStone.isWearing == 1)
                {
                    SMD.rollsminus1 -= 10;
                }
                if (Main.expertMode) { }
                else
                {
                    //    if ( Main.rand.Next(X) = (Y))
                    //    if (Main.rand.Next(2) = (1))//item rarity
                    // {
                    if (Main.rand.Next(1, 4) != 2)
                    {
                        Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("SigilOfFright"), 1, true, -1);
                        // }
                    }
                }
            }
            //  ----------------------------------------------------------------
            if (npc.type == NPCID.WallofFlesh)
            {
                if (SoulStone.isWearing == 1)
                {
                    SMD.rollsminus1 -= 10;
                }
                if (Main.expertMode) { }
                else
                {
                    //    if ( Main.rand.Next(X) = (Y))
                    //    if (Main.rand.Next(2) = (1))//item rarity
                    // {
                    Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("Threat21"), 1, true, -1);
                    // }
                    if(Main.rand.Next(1,11) == 2)
                    {
                        Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("OFlash"), 1, true, -1);
                    }
                    if (Main.rand.Next(1, 4) != 2)
                    {
                        Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("SigilOfHell"), 1, false, -1);

                    }
                    if (Main.rand.Next(1, 101) <= 15)
                    {
                        Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("ADrainBow3"), 1, false, -1);

                    }
                }
            }
            if (npc.type == NPCID.EyeofCthulhu)
            {
                if (SoulStone.isWearing == 1)
                {
                    SMD.rollsminus1 -= 10;
                }
                if (Main.expertMode) { }
                else
                {
                    //    if ( Main.rand.Next(X) = (Y))
                    //    if (Main.rand.Next(2) = (1))//item rarity
                    // {
                    Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("Threat1"), 1, true, -1);
                    // }
                    if (Main.rand.Next(1, 4) != 2)
                    {
                        Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("SigilOfTheForest"), 1, false, -1);

                    }
                }
            }
            if (npc.type == NPCID.BrainofCthulhu)
            {
                if (SoulStone.isWearing == 1)
                {
                    SMD.rollsminus1 -= 10;
                }
                if (Main.expertMode) { }
                else
                {
                    //    if ( Main.rand.Next(X) = (Y))
                    //    if (Main.rand.Next(2) = (1))//item rarity
                    // {
                  
                    // }
                    if (Main.rand.Next(1, 4) != 2)
                    {
                        Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("SigilOfTheCursed"), 1, false, -1);

                    }
                }
            }
            if (npc.type == NPCID.QueenBee)
            {
                if (SoulStone.isWearing == 1)
                {
                    SMD.rollsminus1 -= 10;
                }
                if (Main.expertMode) { }
                else
                {
                    //    if ( Main.rand.Next(X) = (Y))
                    //    if (Main.rand.Next(2) = (1))//item rarity
                    // {

                    // }
                    if (Main.rand.Next(1, 4) != 2)
                    {
                        Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("SigilOfTheJungle"), 1, false, -1);

                    }
                }
            }
            if (npc.type == NPCID.CultistBoss)
            {
                //    if ( Main.rand.Next(X) = (Y))
                //    if (Main.rand.Next(2) = (1))//item rarity
                // {
               
                    Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("Threat4"), 1, false, -1);
                    // }
                
            }
            if (npc.type == NPCID.Plantera)
            {
                if (SoulStone.isWearing == 1)
                {
                    SMD.rollsminus1 -= 10;
                }
                //    if ( Main.rand.Next(X) = (Y))
                //    if (Main.rand.Next(2) = (1))//item rarity
                // {
                if (Main.expertMode) { }
                else
                {
                    Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("Threat3"), 1, false, -1);
                    if (Main.rand.Next(1, 101) <= 15)
                    {
                        Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("ADrainBow4"), 1, false, -1);

                    }
                    // }
                }
            }

            //  ----------------------------------------------------------------


            //  Main.rand(1, 100)

            if (npc.type == NPCID.WitchDoctor)
            {
                if (Main.expertMode)
                {


                 

                    if (Main.rand.Next(1, 101) >= 50)
                    {
                        Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.PygmyNecklace, 1, false, -1);
                    }
                    else
                    {
                        Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.HerculesBeetle, 1, false, -1);
                    }
                }
                else
                {
                   

                    if (Main.rand.Next(1, 5) != 4)
                    {
                       

                        if (Main.rand.Next(1, 101) >= 50)
                        {
                            Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.PygmyNecklace, 1, false, -1);
                        }
                        else
                        {
                            Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.HerculesBeetle, 1, false, -1);
                        }

                    }
                }
            }
            //  ----------------------------------------------------------------
        }
    }
}