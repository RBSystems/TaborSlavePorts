using System;
using Crestron.SimplSharpPro;
using Crestron.SimplSharpPro.EthernetCommunication;
using proAV.Core;
using proAV.Core.Extensions;
using proAV.Core.Utilities;

namespace TaborSlavePorts {
	public class Mc4EiscFactory {
		public EthernetIntersystemCommunications Create() {
			var eisc = new EthernetIntersystemCommunications(0x09, "10.51.10.112", ProAvControlSystem.ControlSystem);
			eisc.Register();
			eisc.OnlineStatusChange += EiscOnOnlineStatusChange;
			ConsoleCommands.Create(x_ => {
				uint join;
				x_.TryParseToUint(out join);
				eisc.BooleanInput[join].Pulse(1000);
			}, "testbool", "testbool joinnumber");
			ConsoleCommands.Create(x_ => {
				uint join;
				x_.TryParseToUint(out join);
				eisc.StringInput[x_].StringValue = DateTime.Now.ToLongTimeString();
			}, "testserial", "testserial joinnumber");
			return eisc;
		}

		private static void EiscOnOnlineStatusChange(GenericBase currentDevice_, OnlineOfflineEventArgs args_) {
			"Eisc Online Status is {0}".PrintLine(args_.DeviceOnLine);
		}
	}
}