// Copyright (c) 2024 EchKode
// SPDX-License-Identifier: BSD-3-Clause

using System;

using HarmonyLib;
using PBModManager = PhantomBrigade.Mods.ModManager;
using UnityEngine;

namespace EchKode.PBMods.StandAndShoot
{
	public partial class ModLink : PhantomBrigade.Mods.ModLink
	{
		internal static int modIndex;
		internal static string modID;
		internal static string modPath;

		public override void OnLoad(Harmony harmonyInstance)
		{
			modID = metadata.id;
			modIndex = PBModManager.metadataPreloadList.FindIndex(mod => StringComparer.Ordinal.Compare(mod.metadata.id, modID) == 0);
			modPath = metadata.path;

			Debug.LogFormat("Mod {0} ({1}) is executing OnLoad | Path: {2}",
				modIndex,
				modID,
				metadata.path);
		}
	}
}
