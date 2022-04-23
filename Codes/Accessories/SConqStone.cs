using Microsoft.Xna.Framework;
using RatFiesta.Buffs;
using RatFiesta.Minions;
using System;
using Terraria;
using System.IO;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.DataStructures;
using Terraria.Utilities;
using System.Linq;
using Terraria.ModLoader.IO;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace RatFiesta.Items.Accessories.Infinity
{
    class SConqStone : ModItem
    {




        public override void SetDefaults()
        {
            Main.RegisterItemAnimation(item.type, new DrawAnimationVertical(30, 2));

            item.width = 38;
            item.height = 38;
            item.accessory = true;
            item.value = Item.sellPrice(platinum: 1);
            item.rare = ItemRarityID.Yellow;
            // item.summon = true;
            item.UseSound = SoundID.Item113;
            item.buffType = ModContent.BuffType<ConqBuff>();
            item.noMelee = true;
            item.noUseGraphic = true;

        }
        public static int CritIncrease;

        public override void SetStaticDefaults()
        {
            ItemID.Sets.ItemNoGravity[item.type] = true;

            DisplayName.SetDefault("Conqueror's Precision");
            Tooltip.SetDefault("");

        }
        public override void ModifyTooltips(List<TooltipLine> tooltips)
        {
            if ((RealityBuff.scenario) >= 10)
            {
                CritIncrease = 25;
            }
            if ((RealityBuff.scenario) == 9)
            {
                CritIncrease = 22;
            }
            if ((RealityBuff.scenario) == 8)
            {

                CritIncrease = 20;
            }
            if ((RealityBuff.scenario) == 7)
            {

                CritIncrease = 17;
            }
            if ((RealityBuff.scenario) == 6)
            {

                CritIncrease = 15;
            }
            if ((RealityBuff.scenario) == 5)
            {

                CritIncrease = 12;
            }
            if ((RealityBuff.scenario) == 4)
            {

                CritIncrease = 10;
            }
            if ((RealityBuff.scenario) == 3)
            {

                CritIncrease = 7;
            }
            if ((RealityBuff.scenario) == 2)
            {

                CritIncrease = 5;
            }
            if ((RealityBuff.scenario) <= 1)
            {

                CritIncrease = 2;
            }

            foreach (TooltipLine line in tooltips)
            {

                if (line.mod == "Terraria" && line.Name == "Tooltip0")
                {
                    line.text = "Increase critical strike chance by " + CritIncrease + "%\nThis value is increased as more bosses are defeated, up to a total of +25%\nYour fighting spirit increases your defense by 1";
                }
            }
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<AKeyStone>());

            recipe.SetResult(this);
            recipe.AddRecipe();
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.statDefense += 1;


            if ((RealityBuff.scenario) >= 10)
            {
                CritIncrease = 25;
            }
            if ((RealityBuff.scenario) == 9)
            {
                CritIncrease = 22;
            }
            if ((RealityBuff.scenario) == 8)
            {

                CritIncrease = 20;
            }
            if ((RealityBuff.scenario) == 7)
            {

                CritIncrease = 17;
            }
            if ((RealityBuff.scenario) == 6)
            {

                CritIncrease = 15;
            }
            if ((RealityBuff.scenario) == 5)
            {

                CritIncrease = 12;
            }
            if ((RealityBuff.scenario) == 4)
            {

                CritIncrease = 10;
            }
            if ((RealityBuff.scenario) == 3)
            {

                CritIncrease = 7;
            }
            if ((RealityBuff.scenario) == 2)
            {

                CritIncrease = 5;
            }
            if ((RealityBuff.scenario) <= 1)
            {

                CritIncrease = 2;
            }
            player.AddBuff(item.buffType, 2);

            player.magicCrit += CritIncrease;
            player.rangedCrit += CritIncrease;
            player.meleeCrit += CritIncrease;
            player.thrownCrit += CritIncrease;
               
         //   bool HasBuff = player.HasBuff(ModContent.BuffType<ConqBuff>());



        //    if (HasBuff != true)

            // if (player.ownedProjectileCounts[ModContent.ProjectileType<ProbeSummon>()] <= 0)
         //   {
                //   Projectile.NewProjectile(player.position.X, player.position.Y, 0f, 0f, ModContent.ProjectileType<ProbeSummon>(), 50, -5f, Main.myPlayer);

            //    player.AddBuff(item.buffType, 2);
          //  }




        }

    }

}