
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
	class DestroyerBuff : ModBuff
	{

		public override void SetDefaults()
		{


			DisplayName.SetDefault("Destroyer");
			Description.SetDefault("After defeating it's father and siblings, it joins you!");
			Main.buffNoSave[Type] = true;
			canBeCleared = false;

			Main.buffNoTimeDisplay[Type] = true;


		}
		public override void Update(Player player, ref int buffIndex)
		{
			int expertdamage;
			if (Main.expertMode == true) { expertdamage = 80; } else { expertdamage = 50; }
			if (player.ownedProjectileCounts[ModContent.ProjectileType<ProbeSummon>()] <= 0)
			{
				Projectile.NewProjectile(player.position.X, player.position.Y, 0f, 0f, ModContent.ProjectileType<ProbeSummon>(), expertdamage, -5f, Main.myPlayer);

				player.buffTime[buffIndex] = 18000;
			}
			else
			{

				player.DelBuff(buffIndex);
				buffIndex--;

			}
		}
	}
}
	
		//	
	


	
