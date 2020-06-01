﻿using Crestron.SimplSharpPro;
using proAV.Core;
using proAV.Core.Extensions;

namespace TaborSlavePorts.PortListeners {
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
					"Outgoing >>> EiscBoolPulse [{0}]".PrintLine(BoolJoins.Io1Fb);
					ControlSystem.MasterProcessorLink.BooleanInput[BoolJoins.Io1Fb].Pulse(1000);
					break;
				case 2:
					"Outgoing >>> EiscBoolPulse [{0}]".PrintLine(BoolJoins.Io2Fb);
					ControlSystem.MasterProcessorLink.BooleanInput[BoolJoins.Io2Fb].Pulse(1000);
					break;
				case 3:
					if (!port_.DigitalIn) {
						"Outgoing >>> EiscBoolPulse [{0}]".PrintLine(BoolJoins.Io3Fb);
						ControlSystem.MasterProcessorLink.BooleanInput[BoolJoins.Io3Fb].Pulse(1000);
					}
					break;
				case 4:
					if (!port_.DigitalIn) {
						"Outgoing >>> EiscBoolPulse [{0}]".PrintLine(BoolJoins.Io4Fb);
						ControlSystem.MasterProcessorLink.BooleanInput[BoolJoins.Io4Fb].Pulse(1000);
					}
					break;
				case 5:
					"Outgoing >>> EiscBoolPulse [{0}]".PrintLine(BoolJoins.Io5Fb);
					ControlSystem.MasterProcessorLink.BooleanInput[BoolJoins.Io5Fb].Pulse(1000);
					break;
				case 6:
					"Outgoing >>> EiscBoolPulse [{0}]".PrintLine(BoolJoins.Io6Fb);
					ControlSystem.MasterProcessorLink.BooleanInput[BoolJoins.Io6Fb].Pulse(1000);
					break;
			}
		}
	}
}