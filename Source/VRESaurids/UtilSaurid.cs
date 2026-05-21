using RimWorld;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using Verse;

namespace VRESaurids
{
    public static class UtilSaurid
    {

        private static bool disabled = false;

		public static bool SameXenotype(Pawn pawn, Pawn other)
		{
			if (disabled)
			{
				if (pawn?.genes?.Xenotype == other?.genes?.Xenotype)
				{
					return true;
				}
				return false;
			}
			try
            {
                return WVC_XenotypesAndGenes.PreferredXenotypesUtility.IsSameXenotype(pawn, other);
            }
            catch
            {
				disabled = true;
			}
			return false;
		}
    }
}
