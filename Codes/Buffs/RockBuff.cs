
using Microsoft.Xna.Framework;
using RatFiesta.Buffs;
using RatFiesta.Minions;
using RatFiesta.Items.Accessories;
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

namespace RatFiesta.Buffs
{
	class RockBuff : ModBuff
	{

		public override void SetDefaults()
		{


			DisplayName.SetDefault("Levitator");
			Description.SetDefault("You've telekinetically control rocks to surround you!");
			Main.buffNoSave[Type] = true;
			canBeCleared = false;

			Main.buffNoTimeDisplay[Type] = true;


		}
		int number = 0;
		public override void Update(Player player, ref int buffIndex)
		{
			int lecock = (Main.rand.Next(50, 250));
			int expertdamage;
			if (Main.expertMode == true) { expertdamage = (Main.rand.Next(4, 6)); } else { expertdamage = 4; }
			if (player.ownedProjectileCounts[ModContent.ProjectileType<RockSummon>()] <= 74)
			{


				Projectile.NewProjectile(player.position.X - 449, player.position.Y + ( lecock - 250), 0f, 0f, ModContent.ProjectileType<RockSummon>(), expertdamage, -5f, Main.myPlayer);
				number += 1;
				player.buffTime[buffIndex] = 18000;
			}
			else
			{
				number = 0;
				player.DelBuff(buffIndex);
				buffIndex--;

			}
		}
	}
}
