using System;
using Crestron.SimplSharpPro;
using proAV.Core;

namespace TaborSlavePorts {
	public class IoListener {

		public IoListener() {
			foreach (var versiPort in ProAvControlSystem.ControlSystem.VersiPorts) {
				versiPort.VersiportChange += VersiPortOnVersiportChange;
			}
		}

		private static void VersiPortOnVersiportChange(Versiport port_, VersiportEventArgs args_) {
			if (port_.DigitalIn) {
				switch (port_.ID) {
					case 1:
						ControlSystem.MasterProcessorLink.BooleanInput[BoolJoins.Io1Fb].BoolValue = true;
						ControlSystem.MasterProcessorLink.BooleanInput[BoolJoins.Io1Fb].BoolValue = false;
						break;
					case 2:
						ControlSystem.MasterProcessorLink.BooleanInput[BoolJoins.Io2Fb].BoolValue = true;
						ControlSystem.MasterProcessorLink.BooleanInput[BoolJoins.Io2Fb].BoolValue = false;
						break;
					case 3:
						ControlSystem.MasterProcessorLink.BooleanInput[BoolJoins.Io3Fb].BoolValue = true;
						ControlSystem.MasterProcessorLink.BooleanInput[BoolJoins.Io3Fb].BoolValue = false;
						break;
					case 4:
						ControlSystem.MasterProcessorLink.BooleanInput[BoolJoins.Io4Fb].BoolValue = true;
						ControlSystem.MasterProcessorLink.BooleanInput[BoolJoins.Io4Fb].BoolValue = false;
						break;
					case 5:
						ControlSystem.MasterProcessorLink.BooleanInput[BoolJoins.Io5Fb].BoolValue = true;
						ControlSystem.MasterProcessorLink.BooleanInput[BoolJoins.Io5Fb].BoolValue = false;
						break;
					case 6:
						ControlSystem.MasterProcessorLink.BooleanInput[BoolJoins.Io6Fb].BoolValue = true;
						ControlSystem.MasterProcessorLink.BooleanInput[BoolJoins.Io6Fb].BoolValue = false;
						break;
				}
			}
		}
	}
}