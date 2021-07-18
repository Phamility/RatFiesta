using Microsoft.Xna.Framework;
using RatFiesta.Buffs;
using RatFiesta.Minions;
using Terraria.DataStructures;
using System;
using Terraria;
using System.IO;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Utilities;
using System.Linq;
using Terraria.ModLoader.IO;
using System.Text;
using System.Threading.Tasks;
using RatFiesta.Items.Accessories.Sigils.SigilOfElements;
using RatFiesta.Items.Accessories.Sigils.SigilOfTech;
using RatFiesta.Items.Accessories.Sigils.SigilOfThelands;
using RatFiesta.Items.Accessories.Sigils.SigilOfTime;
using RatFiesta.Items.Accessories.Sigils.SigilOfUndead;

namespace RatFiesta.Items.Accessories.Sigils
{
    class TSigilOfTheWorld : ModItem
    {




        public override void SetDefaults()
        {
            Main.RegisterItemAnimation(item.type, new DrawAnimationVertical(30, 2));
            //2 Frame animation, 60/30 = 2 times a second.
            item.width = 52;
            item.height = 52;
            //Sprites Image
            item.accessory = true;
            item.value = Item.sellPrice(platinum: 10);
            item.rare = ItemRarityID.Expert;
            //Makes the item rarity rainbow and cool.
            ItemID.Sets.ItemNoGravity[item.type] = true;
            //Allows the item to float
            item.buffType = ModContent.BuffType<DestroyerBuff>();
            //The Destroyer Buff spawns the probe.
            item.noMelee = true;
            item.noUseGraphic = true;
            item.expert = true;
            //I added this so when reforged, it doesn't change colors.
        }


        public override void SetStaticDefaults()
        {
            ItemID.Sets.ItemNoGravity[item.type] = true;
            //Idk why I have it here again, one of them do the job though :P
            DisplayName.SetDefault("Sigil Of The World");
            Tooltip.SetDefault("Increases Damage by 15%. Increases Movement Speed by 20% \nIncreases max amount of minions by 6. Largely increases Minion Knockback.  " +
                "\nProvides a lot of buffs. Increases max health and mana by 100.\n" +
                "Summons a probe that does 50 damage. Emits a bright light around the player.\n" +
                "Grants infinite flight when combined with wings.\n" +
                "The power of this realm is now within the palm of your hand, yet you have the desire for more... \nHide this accessory to reduce the lighting and turn off the probe.");
//Use \n to make the tooltip display go down a line.
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<TSigilOfElementss>());
            recipe.AddIngredient(ModContent.ItemType<TSigilOfTheLands>());
            recipe.AddIngredient(ModContent.ItemType<VSigilOfTimes>());
            recipe.AddIngredient(ModContent.ItemType<SigilOfFlight>());
            recipe.AddIngredient(ModContent.ItemType<TSigilOfEvolution>());
            recipe.AddIngredient(ModContent.ItemType<TSigilOfUndeads>());
            recipe.AddIngredient(ModContent.ItemType<SigilOfReligion>());
            recipe.AddTile(TileID.LunarCraftingStation);
            recipe.SetResult(this);
            recipe.AddRecipe();
            //Bootleg Fargo :D
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.runAcceleration *= 1.2f;
            player.maxRunSpeed *= 1.2f;
            //The 20% Movement speed
            player.maxMinions += 6;
            //Adds Six minions when equipped.
            player.minionKB += 3;
            //Adds alot Minion Knockback (Hercules increases by 1 for reference)
            player.allDamage += .15f;
           //The 15% Damage
            player.AddBuff(BuffID.WellFed, 2);
            player.AddBuff(BuffID.Spelunker, 2);
            player.AddBuff(BuffID.Endurance, 2);
            player.AddBuff(BuffID.MagicPower, 2);
            player.AddBuff(BuffID.Gills, 2);
            player.AddBuff(BuffID.Regeneration, 2);
            player.AddBuff(BuffID.Summoning, 2);
               player.AddBuff(BuffID.Wrath, 2);
            player.AddBuff(BuffID.Thorns, 2);
            player.AddBuff(BuffID.Ironskin, 2);
            player.AddBuff(BuffID.Lifeforce, 2);
            player.AddBuff(BuffID.ObsidianSkin, 2);
            //Adds a bunch of buffs

            player.statManaMax2 += 100;
            player.statLifeMax2 += 100;
          
            player.wingTime *= 100;
            //Makes the player fly for ever, note mounts cancel this
            bool HasBuff = player.HasBuff(ModContent.BuffType<DestroyerBuff>());
            
      

            if (hideVisual == true)
           //When hidden, reduces the light
            {
                Lighting.AddLight(player.position, 1.0f, 1.0f, 1.0f);

            }
            else
            {

                if (HasBuff != true)
            //If I dont have the Destroyer buff, add the Destroyer Buff
            
                {
                  

                    player.AddBuff(item.buffType, 2);
                }
                Lighting.AddLight(player.position, 14f, 14f, 14f);
                player.AddBuff(ModContent.BuffType<TrueSightBuff>(), 2);
            }
            player.statDefense += 15;
            //Just adds 15 defense, duh.
        }
    }
}

