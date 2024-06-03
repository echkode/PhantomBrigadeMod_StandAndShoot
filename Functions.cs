using System.Collections.Generic;
using System.Linq;

using Content.Code.Utility;
using PhantomBrigade;
using PhantomBrigade.Functions;

namespace EchKode.PBMods.StandAndShoot.Functions
{
	[TypeHinted]
	[System.Serializable]
	public sealed class CombatActionValidatePart : ICombatActionValidationFunction
	{
		public string socket;
		public string preset;
		public Dictionary<string, bool> tags;
		public bool present;

		public bool IsValid(CombatEntity unitCombat)
		{
			if (unitCombat == null || string.IsNullOrEmpty(socket))
			{
				return false;
			}

			var unitPersistent = IDUtility.GetLinkedPersistentEntity(unitCombat);
			if (unitPersistent == null)
			{
				return false;
			}

			var part = EquipmentUtility.GetPartInUnit(unitPersistent, socket);
			if (part == null || !part.isPart || part.isWrecked)
			{
				return !present;
			}

			if (!string.IsNullOrEmpty(preset))
			{
				var expected = part.hasDataKeyPartPreset && string.CompareOrdinal(part.dataKeyPartPreset.s, preset) == 0;
				return present == expected;
			}

			if (tags == null || tags.Count == 0)
			{
				return !present;
			}

			if (part.hasTagCache && part.tagCache.tags != null)
			{
				var partTags = part.tagCache.tags;
				return present == tags.All(kvp => kvp.Value == partTags.Contains(kvp.Key));
			}

			return present && tags.All(kvp => !kvp.Value);
		}
	}
}
