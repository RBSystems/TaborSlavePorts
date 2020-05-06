using Crestron.SimplSharpPro;
using Crestron.SimplSharpPro.EthernetCommunication;
using proAV.Core;
using proAV.Core.Extensions;

namespace TaborSlavePorts {
	public class EiscHandler {
		public EthernetIntersystemCommunications Create(){
			var eisc = new EthernetIntersystemCommunications(0x09, "10.51.10.112", ProAvControlSystem.ControlSystem);
			eisc.Register();
			eisc.OnlineStatusChange += EiscOnOnlineStatusChange;
			return eisc;
		}

		private static void EiscOnOnlineStatusChange(GenericBase currentDevice_, OnlineOfflineEventArgs args_){
			"Eisc Online Status is {0}".PrintLine(args_.DeviceOnLine);
		}
	}
}