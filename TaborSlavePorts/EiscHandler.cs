using System;
using Crestron.SimplSharpPro;
using Crestron.SimplSharpPro.EthernetCommunication;
using proAV.Core;
using proAV.Core.Extensions;
using proAV.Core.Utilities;

namespace TaborSlavePorts {
	public class EiscHandler {
		public EthernetIntersystemCommunications Create() {
			var eisc = new EthernetIntersystemCommunications(0x09, "10.51.10.112", ProAvControlSystem.ControlSystem);
			eisc.Register();
			eisc.OnlineStatusChange += EiscOnOnlineStatusChange;
			ConsoleCommands.Create(x_ => {
				eisc.BooleanInput[17].Pulse(1000);
			}, "testbool", "");
			ConsoleCommands.Create(x_ => {
				eisc.StringInput[1].StringValue = DateTime.Now.ToLongTimeString();
			}, "teststring", "");
			return eisc;
		}

		private static void EiscOnOnlineStatusChange(GenericBase currentDevice_, OnlineOfflineEventArgs args_) {
			"Eisc Online Status is {0}".PrintLine(args_.DeviceOnLine);
		}
	}
}