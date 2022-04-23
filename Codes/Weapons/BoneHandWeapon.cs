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

namespace RatFiesta.Items.Weapons
{
	class BoneHandWeapon : ModItem
	{

		int numberProjectiles = 2;
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Bony Hands Staff");
			Tooltip.SetDefault("Summons a pair of skeleton hands to fight for you.\nThese hands appear to be reluctant to work for you,\nyet their aura screams out 'PUT YOUR PAWS UP'! ");

			

			ItemID.Sets.GamepadWholeScreenUseRange[item.type] = true; // This lets the player target anywhere on the whole screen while using a controller.
			ItemID.Sets.LockOnIgnoresCollision[item.type] = true;
		}
      

        public override void SetDefaults()
		{
			item.damage = 30;
			item.knockBack = -3f;
			item.mana = 10;
			item.width = 32;
			item.autoReuse = true;
			item.height = 32;
			item.useTime = 12;
			item.useAnimation = 12;
			item.useStyle = ItemUseStyleID.SwingThrow;
			item.value = Item.buyPrice(1, 0, 0, 0);
			item.rare = ItemRarityID.Orange;
			item.summon = true;
			item.UseSound = SoundID.Item76;
			item.buffType = ModContent.BuffType<PawsUpBuff>();
			// These below are needed for a minion weapon
			item.noMelee = true;
			// No buffTime because otherwise the item tooltip would say something like "1 minute duration"
			item.shoot = ModContent.ProjectileType<BoneHandSummon>();

		}
		// if (Main.GameUpdateCount % 60 == 0) TIMER
		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{


			{
				for (int i = 0; i < numberProjectiles; i++)
				{
					Projectile.NewProjectile(Main.MouseWorld.X, Main.MouseWorld.Y, speedX, speedY, type, damage, knockBack, Main.myPlayer);
				}
				// This is needed so the buff that keeps your minion alive and allows you to despawn it properly applies
			}
			player.AddBuff(ModContent.BuffType<PawsUpBuff>(), 2);


			// Here you can change where the minion is spawned. Most vanilla minions spawn at the cursor position.
			position = Main.MouseWorld;
			return false;
		}

	
	}
}

