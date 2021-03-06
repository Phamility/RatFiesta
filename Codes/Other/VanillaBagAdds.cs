
using RatFiesta.Items.Weapons;
//using RatFiesta.Items.Drops;
using RatFiesta.Items.Accessories.Sigils.SigilOfThelands;
using RatFiesta.Items.Accessories.Sigils.SigilOfTech;
using RatFiesta.Items.Accessories;
using RatFiesta.Items.XConsumables;
using RatFiesta.Items.Drops;
using Terraria;
using Terraria.ID;
using RatFiesta.ZArmors;
using Terraria.ModLoader;
using System.Collections.Generic;

namespace ExampleMod.Items
{
	public class VanillaBagAdds : GlobalItem
	{
		public override void ModifyTooltips(Item item, List<TooltipLine> tooltips)
		{
			if (item.type == ItemID.Mushroom)
			{
				foreach (TooltipLine line in tooltips)
				{
					if (line.mod == "Terraria" && line.Name != "Consumable" && line.Name != "ItemName" && line.text != "30 second duration")
					{
						line.text = "Material\nWhen consumed, provide the Campfire buff!";
					}
				}


			}
		}
		public override void SetDefaults(Item item)
		{
			
			if (item.type == ItemID.Mushroom)
			{
			
					//item.CloneDefaults(ItemID.Mushroom);
					//	item.consumable = true;
					//	item.accessory = true;
				item.buffType = 87;
				item.buffTime = 30 * 60;
				item.healLife = 0;
				item.potion = false;
			}
		}
        public override void OnConsumeItem(Item item, Player player)
        {
		if(item.type == ItemID.Mushroom)
            {
			//	item.buffType = 87;
			//	item.buffTime = 30 * 60;
				item.healLife = 0;
				item.potion = false;
				player.AddBuff(BuffID.Campfire, (60 * 30), false);
			}

		}

        public override void OpenVanillaBag(string context, Player player, int arg)
		{
			if (context == "bossBag")
			{
				if(Main.rand.Next(1,6)== 2)
                {
					player.QuickSpawnItem(ItemID.LifeCrystal);

				}
				if (Main.rand.Next(1, 71) == 2)
				{
					player.QuickSpawnItem(ModContent.ItemType<OStinky>());

				}
				if (Main.rand.Next(1, 21) == 2)
				{
					if (Main.rand.Next(1, 4) == 2)
					{

						player.QuickSpawnItem(ModContent.ItemType<AAAPhamilityHead>());
						player.QuickSpawnItem(ModContent.ItemType<AAPhamilityChest>());
						player.QuickSpawnItem(ModContent.ItemType<ABPhamilityLegs>());

					}
					else if(Main.rand.Next(1,3) == 2) {
						{
							player.QuickSpawnItem(ModContent.ItemType<ACHoodie>());
							player.QuickSpawnItem(ModContent.ItemType<Blacks>());
							player.QuickSpawnItem(ModContent.ItemType<BlacksLegs>());

						}
					} else
					{
						player.QuickSpawnItem(ModContent.ItemType<CCNatsuki>());
						player.QuickSpawnItem(ModContent.ItemType<CNatsuki>());
						player.QuickSpawnItem(ModContent.ItemType<CNatsukiLegs>());

					}


				}
			
			}
			// This method shows adding items to Fishrons boss bag. 
			// Typically you'll also want to also add an item to the non-expert boss drops, that code can be found in ExampleGlobalNPC.NPCLoot. Use this and that to add drops to bosses.
			if (context == "bossBag" && arg == ItemID.SkeletronBossBag)
			{
				player.QuickSpawnItem(ModContent.ItemType<Threat2>());
				player.QuickSpawnItem(ModContent.ItemType<BoneHandWeapon>());
				player.QuickSpawnItem(ModContent.ItemType<SigilOfTheDungeon>());

				if (Main.rand.Next(1, 101) <= 40)
				{
					player.QuickSpawnItem(ModContent.ItemType<ADrainBow2>());

				}
			}
			//--------------------------------------------------------------------
			if (context == "bossBag" && arg == ItemID.EaterOfWorldsBossBag)
			{
				player.QuickSpawnItem(ModContent.ItemType<SigilOfTheCursed>());
			}
			//--------------------------------------------------------------------
			if (context == "bossBag" && arg == ItemID.BrainOfCthulhuBossBag)
			{
				player.QuickSpawnItem(ModContent.ItemType<SigilOfTheCursed>());
			}
			//--------------------------------------------------------------------
			if (context == "bossBag" && arg == ItemID.FishronBossBag)
			{
				player.QuickSpawnItem(ModContent.ItemType<FishronFin>());
				player.QuickSpawnItem(ModContent.ItemType<SigilOfTheBeach>());
			}
			//--------------------------------------------------------------------
			if (context == "bossBag" && arg == ItemID.GolemBossBag)
			{
				if (Main.rand.Next(1, 3) == 2)
				{
					player.QuickSpawnItem(ModContent.ItemType<ZGolemsContract>());

				}
				if (Main.rand.Next(1, 6) == 2)
				{
					player.QuickSpawnItem(ModContent.ItemType<ODefense>());
				}
			}
			//--------------------------------------------------------------------
			if (context == "bossBag" && arg == ItemID.MoonLordBossBag)
			{
				player.QuickSpawnItem(ModContent.ItemType<NDarkContinentFragment>());
			}
			//--------------------------------------------------------------------

			if (context == "bossBag" && arg == ItemID.TwinsBossBag)
			{
				player.QuickSpawnItem(ModContent.ItemType<SigilOfSight>());
			}
			//--------------------------------------------------------------------

			if (context == "bossBag" && arg == ItemID.DestroyerBossBag)
			{
				player.QuickSpawnItem(ModContent.ItemType<SigilOfMight>());

			}
			//--------------------------------------------------------------------
			if (context == "bossBag" && arg == ItemID.SkeletronPrimeBossBag)
			{
				player.QuickSpawnItem(ModContent.ItemType<SigilOfFright>());
				

			}
			//--------------------------------------------------------------------
			if (context == "bossBag" && arg == ItemID.WallOfFleshBossBag)
			{


				if (Main.rand.Next(1, 101) <= 25)
				{
					player.QuickSpawnItem(ModContent.ItemType<ADrainBow3>());

				}

				if (Main.rand.Next(1,3) == 2)
                    {
						if (Main.rand.Next(1, 3) == 2)
						{
							if (Main.rand.Next(1, 3) == 2)
							{
								player.QuickSpawnItem(ItemID.TrifoldMap);
							}
							else
							{
								player.QuickSpawnItem(ItemID.FastClock);

							}
						}
						else
						{
							if (Main.rand.Next(1, 3) == 2)
							{
								player.QuickSpawnItem(ItemID.AdhesiveBandage);

							}
							else
							{
								player.QuickSpawnItem(ItemID.Bezoar);

							}
						}
					}
                    else
                    {
						if (Main.rand.Next(1, 3) == 2)
						{
							if (Main.rand.Next(1, 3) == 2)
							{
								player.QuickSpawnItem(ItemID.Megaphone);

							}
							else
							{
								player.QuickSpawnItem(ItemID.Nazar);

							}
						}
						else
						{
							if (Main.rand.Next(1, 3) == 2)
							{
								player.QuickSpawnItem(ItemID.ArmorPolish);

							}
							else
							{
								player.QuickSpawnItem(ItemID.Vitamins);

							}
						}
					



                }
				player.QuickSpawnItem(ModContent.ItemType<Threat21>());

				player.QuickSpawnItem(ModContent.ItemType<SigilOfHell>());
				if (Main.rand.Next(1, 8) == 2)
				{
					player.QuickSpawnItem(ModContent.ItemType<OFlash>());
				}
				player.QuickSpawnItem(ModContent.ItemType<AAHERO>(), Main.rand.Next(1,3));


			}
			//--------------------------------------------------------------------
			if (context == "bossBag" && arg == ItemID.EyeOfCthulhuBossBag)
			{
				player.QuickSpawnItem(ModContent.ItemType<Threat1>());
				player.QuickSpawnItem(ModContent.ItemType<SigilOfTheForest>());

			}
			//--------------------------------------------------------------------
			if (context == "bossBag" && arg == ItemID.PlanteraBossBag)
			{
				player.QuickSpawnItem(ModContent.ItemType<Threat3>());
				if (Main.rand.Next(1, 101) <= 25)
				{
					player.QuickSpawnItem(ModContent.ItemType<ADrainBow4>());

				}

			}
			//--------------------------------------------------------------------
			if (context == "bossBag" && arg == ItemID.QueenBeeBossBag)
			{
			
				player.QuickSpawnItem(ModContent.ItemType<SigilOfTheJungle>());
			}
			//--------------------------------------------------------------------



		}
	}
}