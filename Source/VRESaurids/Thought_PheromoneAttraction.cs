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
    public class Thought_PheromoneAttraction : Thought_SituationalSocial
	{
		public override float OpinionOffset()
		{
			return UtilSaurid.SameXenotype(pawn, OtherPawn()) ? (Gene_Pheromones.PheromonesPawns.Contains(OtherPawn()) ? 20 : 0) : 0;
		}
	}
}
