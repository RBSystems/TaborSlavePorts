using Crestron.SimplSharpPro;
using proAV.Core;
using proAV.Core.Extensions;

namespace TaborSlavePorts {
	public class IoListener {

		public IoListener() {
			foreach (var versiPort in ProAvControlSystem.ControlSystem.VersiPorts) {
				versiPort.VersiportChange += VersiPortOnVersiportChange;
			}
		}

		private static void VersiPortOnVersiportChange(Versiport port_, VersiportEventArgs args_) {
			"VersiPort {0} Event {1}".PrintLine(port_.ID, args_.Event.ToString());
			switch (port_.ID) {
				case 1:
					"Setting Bool {0} to {1}".PrintLine(BoolJoins.Io1Fb, args_.Event == eVersiportEvent.DigitalInChange);
					ControlSystem.MasterProcessorLink.BooleanInput[BoolJoins.Io1Fb].Pulse(1000);
					break;
				case 2:
					"Setting Bool {0} to {1}".PrintLine(BoolJoins.Io2Fb, args_.Event == eVersiportEvent.DigitalInChange);
					ControlSystem.MasterProcessorLink.BooleanInput[BoolJoins.Io2Fb].Pulse(1000);
					break;
				case 3:
					"Setting Bool {0} to {1}".PrintLine(BoolJoins.Io3Fb, args_.Event == eVersiportEvent.DigitalInChange);
					ControlSystem.MasterProcessorLink.BooleanInput[BoolJoins.Io3Fb].Pulse(1000);
					break;
				case 4:
					"Setting Bool {0} to {1}".PrintLine(BoolJoins.Io4Fb, args_.Event == eVersiportEvent.DigitalInChange);
					ControlSystem.MasterProcessorLink.BooleanInput[BoolJoins.Io4Fb].Pulse(1000);
					break;
				case 5:
					"Setting Bool {0} to {1}".PrintLine(BoolJoins.Io5Fb, args_.Event == eVersiportEvent.DigitalInChange);
					ControlSystem.MasterProcessorLink.BooleanInput[BoolJoins.Io5Fb].Pulse(1000);
					break;
				case 6:
					"Setting Bool {0} to {1}".PrintLine(BoolJoins.Io6Fb, args_.Event == eVersiportEvent.DigitalInChange);
					ControlSystem.MasterProcessorLink.BooleanInput[BoolJoins.Io6Fb].Pulse(1000);
					break;
			}
		}
	}
}