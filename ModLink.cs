// Copyright (c) 2024 EchKode
// SPDX-License-Identifier: BSD-3-Clause

namespace EchKode.PBMods.StandAndShoot
{
	public partial class ModLink : PhantomBrigade.Mods.ModLink
	{
		internal static int ModIndex;
		internal static string ModID;
		internal static string ModPath;

		public override void OnLoadStart()
		{
			ModIndex = modIndexPreload;
			ModID = modID;
			ModPath = modPath;
		}
	}
}
