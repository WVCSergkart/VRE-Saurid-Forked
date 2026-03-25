using RimWorld;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using Verse;
using WVC_XenotypesAndGenes;

namespace VRESaurids
{
    public class ThoughtWorker_PheromoneAttraction : ThoughtWorker
	{
		protected override ThoughtState CurrentSocialStateInternal(Pawn p, Pawn otherPawn)
		{
			if (!UtilSaurid.SameXenotype(p, otherPawn) || !RelationsUtility.PawnsKnowEachOther(p, otherPawn))
			{
				return false;
			}
			if (Gene_Pheromones.PheromonesPawns.Contains(otherPawn))
			{
				return ThoughtState.ActiveAtStage(1);
			}
			return false;
		}
	}
}
