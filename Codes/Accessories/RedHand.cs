using Microsoft.Xna.Framework;
using RatFiesta.Buffs;
using RatFiesta.Minions;
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
namespace RatFiesta.Items.Accessories
{
    class RedHand : ModItem
    {




        public override void SetDefaults()
        {

            item.width = 32;
            item.height = 32;
            item.accessory = true;
            item.value = Item.sellPrice(gold: 5);
            item.rare = ItemRarityID.Green;
            // item.summon = true;
            item.UseSound = SoundID.Item113;
            item.buffType = ModContent.BuffType<RedHandBuff>();
            item.noMelee = true;
            item.noUseGraphic = true;

        }


        public override void SetStaticDefaults()
        {
            ItemID.Sets.ItemNoGravity[item.type] = true;

            DisplayName.SetDefault("The Dreamer's Hand");

            Tooltip.SetDefault("Wearing this item summons 3 Steak Knives around you that do 25 damage and attack for you.\n" +
                "Damage is increased to 33 in expert mode.\nDamage isn't affected by buffs.\n" +
                "Something is hidden...");

        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.ThrowingKnife, 30);
            recipe.AddRecipeGroup(mod.Name + ":EvilFlesh", 6);

            recipe.SetResult(this);
            recipe.AddRecipe();
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {





            bool HasBuff = player.HasBuff(ModContent.BuffType<RedHandBuff>());



            if (HasBuff != true)

            // if (player.ownedProjectileCounts[ModContent.ProjectileType<ProbeSummon>()] <= 0)
            {
                //   Projectile.NewProjectile(player.position.X, player.position.Y, 0f, 0f, ModContent.ProjectileType<ProbeSummon>(), 50, -5f, Main.myPlayer);

                player.AddBuff(item.buffType, 2);
            }




        }

    }

}

