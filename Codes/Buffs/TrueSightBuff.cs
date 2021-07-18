
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

namespace RatFiesta.Buffs
{
	class TrueSightBuff : ModBuff
	{
		public override void SetDefaults()
		{
//Just a simple buff that shows it's self when a certain accessory is equipped, doesn't do anything besides show itself .-.
			DisplayName.SetDefault("True Sight");
			Description.SetDefault("A large light surrounds you!");
			Main.buffNoSave[Type] = true;
			Main.buffNoTimeDisplay[Type] = true;
		}

	}
}
