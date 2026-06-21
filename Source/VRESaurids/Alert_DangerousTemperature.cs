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
    public class Alert_DangerousTemperature : Alert_Critical
    {


        public List<Pawn> culpritsResult = new List<Pawn>();

        public List<string> culpritsNames = new List<string>();

        public List<Pawn> Culprits
        {
            get
			{
				if (!VRESauridsMod.settings.displayColdBloodedWarnings)
				{
                    return [];
				}
				culpritsResult.Clear();
                culpritsNames.Clear();
				foreach (Pawn item in WVC_XenotypesAndGenes.Gene_ColdBlooded.ColdBloodedPawns.Where(pawn => !pawn.Suspended))
				{
					Hediff hyper = item.health.hediffSet.GetFirstHediffOfDef(VRESauridsDefOf.VRESaurids_HyperthermicSlowdown);
					if (hyper != null && hyper.Severity >= 0.1f)
					{
						culpritsResult.Add(item);
						culpritsNames.Add(item.Name.ToStringShort);
					}
					Hediff hypo = item.health.hediffSet.GetFirstHediffOfDef(VRESauridsDefOf.VRESaurids_HypothermicSlowdown);
					if (hypo != null && hypo.Severity >= 0.1f)
					{
						culpritsResult.Add(item);
						culpritsNames.Add(item.Name.ToStringShort);
					}
				}
				return culpritsResult;
            }
        }

        public override string GetLabel()
        {
            return "VRESaurids.ColdBloodedDanger".Translate();
        }

        public override TaggedString GetExplanation()
        {
            return "VRESaurids.ColdBloodedDangerExplanation".Translate() + ":\n" + culpritsNames.ToLineList("  - ");
        }

        public override AlertReport GetReport()
        {
            return AlertReport.CulpritsAre(Culprits);
        }
    }
}
