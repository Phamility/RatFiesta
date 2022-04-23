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
namespace RatFiesta.Items.Accessories.Infinity
{
    class Comet : ModItem
    {




        public override void SetDefaults()
        {
            Main.RegisterItemAnimation(item.type, new DrawAnimationVertical(30, 2));

            item.width = 38;
            item.height = 38;
            item.accessory = true;
            item.value = Item.sellPrice(platinum: 1);
            item.rare = ItemRarityID.Cyan;
            // item.summon = true;
            item.UseSound = SoundID.Item113;
            item.buffType = ModContent.BuffType<CometBuff>();
            item.noMelee = true;
            item.noUseGraphic = true;

        }


        public override void SetStaticDefaults()
        {
            ItemID.Sets.ItemNoGravity[item.type] = true;

            DisplayName.SetDefault("Unsealed Inspiration");
            Tooltip.SetDefault("Conjure magical swords from the sky that deal damage, and inflict debuffs.\nMore debuffs appear as more bosses are defeated.\nUsing this power takes a toll on your body, lowering your defense by 2");

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


            player.AddBuff(item.buffType, 2);

            player.statDefense -= 3;
         //   bool HasBuff = player.HasBuff(ModContent.BuffType<CometBuff>());



          //  if (HasBuff != true)

            // if (player.ownedProjectileCounts[ModContent.ProjectileType<ProbeSummon>()] <= 0)
           // {
                //   Projectile.NewProjectile(player.position.X, player.position.Y, 0f, 0f, ModContent.ProjectileType<ProbeSummon>(), 50, -5f, Main.myPlayer);

           //     player.AddBuff(item.buffType, 2);
         //   }




        }

    }

}
