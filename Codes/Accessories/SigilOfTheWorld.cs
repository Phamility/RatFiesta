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
    class SigilOfTheWorld : ModItem
    {
        public override void SetDefaults()
        {
            Main.RegisterItemAnimation(item.type, new DrawAnimationVertical(30, 2));
            //The 30 means it switches frame (60/30) a second, the 2 means how many frames their are on the sprite. 
            // When making animation sprites, make sure they are vertical and a padding of 2.
            item.width = 52;
            item.height = 52;
            item.accessory = true;
            item.value = Item.sellPrice(platinum: 10);
            item.rare = ItemRarityID.Expert;
            ItemID.Sets.ItemNoGravity[item.type] = true;
            //Makes the item float
            item.buffType = ModContent.BuffType<DestroyerBuff>();
            //Reference Rat Fiesta -> Codes -> Buffs
            item.expert = true;
        }
        public override void SetStaticDefaults()
        {
            ItemID.Sets.ItemNoGravity[item.type] = true;
            //Looking back, I wrote this line twice .-. One of them work :D

            DisplayName.SetDefault("Sigil Of The World");
            Tooltip.SetDefault("Increases Damage by 15%. Increases Movement Speed by 20% \nIncreases max amount of minions by 6. Largely increases Minion Knockback.  " +
                "\nProvides a lot of buffs. Increases max health and mana by 100.\n" +
                "Summons a probe that does 50 damage. Emits a bright light around the player.\n" +
                "Grants infinite flight when combined with wings.\n" +
                "The power of this realm is now within the palm of your hand, yet you have the desire for more... \nHide this accessory to reduce the lighting and turn off the probe.");
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
            //Boot leg Fargos :D
        }
        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.runAcceleration *= 1.2f;
            player.maxRunSpeed *= 1.2f;
            //The +20% Movement Speed
            player.maxMinions += 6;
            //When equipped +6 Max minions.
            player.minionKB += 3;
            //For reference, hercules beetle adds +1 knockback.
            player.allDamage += .15f;        
            //The +15% Damage
            player.AddBuff(BuffID.WellFed, 2);
            player.AddBuff(BuffID.Spelunker, 2);
            player.AddBuff(BuffID.Endurance, 2);
            player.AddBuff(BuffID.MagicPower, 2);
            player.AddBuff(BuffID.Gills, 2);
            player.AddBuff(BuffID.Regeneration, 2);
            player.AddBuff(BuffID.Summoning, 2);
            player.AddBuff(BuffID.Thorns, 2);
            player.AddBuff(BuffID.Ironskin, 2);
            player.AddBuff(BuffID.ObsidianSkin, 2);
            player.AddBuff(BuffID.Lifeforce, 2);
            player.AddBuff(BuffID.Wrath, 2);
            //Adds a bunch of buffs for 2/60 a second when equipped (When taking off, they'll go away duh)

            player.statManaMax2 += 100;
            player.statLifeMax2 += 100;
            //NEVER TOUCH STATLIFEMAX OR STATMANAMAX, NEVER!!!
            //statLifeMax2 and statManaMax2 adds stats to the player's health and mana. 

            player.wingTime *= 100;
            //Tbh, I wanted to make a 15% wing flight time, but didn't know how (First mod) , so I just did this to make them fly forever :D
            player.statDefense += 15;
            //Simply adds 15 defense.
            
            bool HasBuff = player.HasBuff(ModContent.BuffType<DestroyerBuff>());
            if (hideVisual == true)
            //That icon right of your accessories, if it's greyed out, that means hideVisual == true, that means that in this case, the lighting around the player is reduced
            {
                Lighting.AddLight(player.position, 1.0f, 1.0f, 1.0f);
            }
            else
            //Else, that means if it's visibile, in this case, their will be a bright light surrounding the player.
            
            {
                if (HasBuff != true)
             {
                    player.AddBuff(item.buffType, 2);
                    //This "Destroyer Buff" is only added when the accessory is visible.
             }
                Lighting.AddLight(player.position, 14f, 14f, 14f);
                player.AddBuff(ModContent.BuffType<TrueSightBuff>(), 2);
                //Reference Rat Fiesta -> Codes -> Buffs
            }
        }
    }
}

