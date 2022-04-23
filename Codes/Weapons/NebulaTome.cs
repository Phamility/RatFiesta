using System;
using RatFiesta.Buffs;
using RatFiesta.Minions;
using RatFiesta.Minions.Reality;
using Terraria;
using System.IO;
using Microsoft.Xna.Framework;

using Terraria.ID;
using Terraria.DataStructures;
using Terraria.ModLoader;
using Terraria.Utilities;
using System.Linq;
using Terraria.ModLoader.IO;
using System.Text;
using System.Threading.Tasks;
using RatFiesta.Mods;
using RatFiesta.Items.Drops;
using RatFiesta.Items.XConsumables;
namespace RatFiesta.Items.Weapons
{
    public class NebulaTome : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("White Nebula");
            Tooltip.SetDefault("Summons a pillar from the sky that strikes enemies up to 12 enemies!\nAn indescribale message from A Mysterious Force can be heard in your head.\nThe message gives you the thoughts of 'How' 'Invite' 'Reward' and 'Unimaginable'");
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);

            recipe.AddIngredient(ItemID.SpellTome);
            recipe.AddIngredient(ModContent.ItemType<NDarkContinentFragment>());
            recipe.AddIngredient(ItemID.FragmentNebula, 4);

            recipe.AddTile(TileID.LunarCraftingStation);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
        public override void SetDefaults()
        {

            item.damage = 2222;
            item.magic = true;
            item.width = 30;
            item.mana = 300;
            item.height = 28;
            item.maxStack = 1;

            item.useTime = 160;
            item.useAnimation = 160;
            item.useStyle = 5;
            item.knockBack = 10f;
            item.value = Item.sellPrice(platinum: 12);
            item.rare = ItemRarityID.Expert;
            item.expert = true;

            item.UseSound = SoundID.Item69;
            item.noMelee = true;
            //      item.shootSpeed = 4f;
            item.autoReuse = false;
            item.shoot = ModContent.ProjectileType<DCPillar2>();

        }
        public int positive;
        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            if(player.direction > 0)
            {
                positive = 1;
            }
            else
            {
                positive = -1;
            }
            Projectile.NewProjectile(Main.MouseWorld.X, player.position.Y - 800, 0f, 0f, ModContent.ProjectileType<DCPillar2>(), damage, 10f, player.whoAmI);
            return false;

        }
    }
}