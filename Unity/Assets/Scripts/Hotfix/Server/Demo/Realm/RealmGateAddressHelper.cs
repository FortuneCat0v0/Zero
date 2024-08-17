using System.Collections.Generic;

namespace ET.Server
{
	public static partial class RealmGateAddressHelper
	{
		public static StartSceneConfig GetGate(int zone, string account)
		{
			ulong hash = (ulong)account.GetLongHashCode();
			
			List<StartSceneConfig> zoneGates = StartSceneConfigCategory.Instance.Gates[zone];
			
			return zoneGates[(int)(hash % (ulong)zoneGates.Count)];
		}
		
		public static StartSceneConfig GetGate(int zone, long accountId)
		{
			ulong hash = (ulong)accountId.GetHashCode();

			List<StartSceneConfig> zoneGates = StartSceneConfigCategory.Instance.Gates[zone];

			return zoneGates[(int)(hash % (ulong)zoneGates.Count)];
		}
		
		public static StartSceneConfig GetRealm(int zone)
		{
			StartSceneConfig zoneRealm = StartSceneConfigCategory.Instance.Realms[zone];
			return zoneRealm;
		}
	}
}
