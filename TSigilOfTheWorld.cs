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

            item.width = 52;
            item.height = 52;
            item.accessory = true;
            item.value = Item.sellPrice(platinum: 10);
            item.rare = ItemRarityID.Expert;
            // item.summon = true;
            ItemID.Sets.ItemNoGravity[item.type] = true;
            item.buffType = ModContent.BuffType<DestroyerBuff>();
            item.noMelee = true;
            item.noUseGraphic = true;
            item.expert = true;
        }


        public override void SetStaticDefaults()
        {
            ItemID.Sets.ItemNoGravity[item.type] = true;

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
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.runAcceleration *= 1.2f;
            player.maxRunSpeed *= 1.2f;
            player.maxMinions += 6;
            player.minionKB += 3;
            player.allDamage += .15f;
           
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

            player.statManaMax2 += 100;
            player.statLifeMax2 += 100;
            player.statLifeMax2 += 20;
            player.statLifeMax2 -= 20;
            player.statManaMax2 += 20;
            player.statManaMax2 -= 20;

            player.wingTime *= 100;
            bool HasBuff = player.HasBuff(ModContent.BuffType<DestroyerBuff>());
            player.AddBuff(BuffID.Lifeforce, 2);

            if (hideVisual == true)
            {
                Lighting.AddLight(player.position, 1.0f, 1.0f, 1.0f);

            }
            else
            {

                if (HasBuff != true)

                // if (player.ownedProjectileCounts[ModContent.ProjectileType<ProbeSummon>()] <= 0)
                {
                    //   Projectile.NewProjectile(player.position.X, player.position.Y, 0f, 0f, ModContent.ProjectileType<ProbeSummon>(), 50, -5f, Main.myPlayer);

                    player.AddBuff(item.buffType, 2);
                }
                Lighting.AddLight(player.position, 14f, 14f, 14f);
                player.AddBuff(ModContent.BuffType<TrueSightBuff>(), 2);
            }
            player.statDefense += 15;

          

            player.AddBuff(BuffID.Wrath, 2);

           
            


        }

    }

}

