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
			if (!Gene_Pheromones.PheromonesPawns.Contains(OtherPawn()))
			{
				return 0f;
			}
			return UtilSaurid.SameXenotype(pawn, OtherPawn()) ?  20 : 0;
		}
	}
}
