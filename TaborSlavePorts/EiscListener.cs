using Crestron.SimplSharpPro;
using Crestron.SimplSharpPro.DeviceSupport;
using proAV.Core;
using proAV.Core.Extensions;

namespace TaborSlavePorts {
	public class EiscListener {
		public EiscListener() {
			ControlSystem.MasterProcessorLink.SigChange += MasterProcessorLinkOnSigChange;
		}

		private static void MasterProcessorLinkOnSigChange(BasicTriList currentDevice_, SigEventArgs args_) {
			if (args_.Sig.Type == eSigType.String) {
				"EiscSerialData [{0}]: {1}".PrintLine(args_.Sig.Number, args_.Sig.StringValue);
				switch (args_.Sig.Number) {
					case SerialJoins.ComPort1:
						ProAvControlSystem.ComPorts[1].Send(args_.Sig.StringValue);
						break;
					case SerialJoins.ComPort2:
						ProAvControlSystem.ComPorts[2].Send(args_.Sig.StringValue);
						break;
					case SerialJoins.ComPort3:
						ProAvControlSystem.ComPorts[3].Send(args_.Sig.StringValue);
						break;
					case SerialJoins.ComPort4:
						ProAvControlSystem.ComPorts[4].Send(args_.Sig.StringValue);
						break;
					case SerialJoins.ComPort5:
						ProAvControlSystem.ComPorts[5].Send(args_.Sig.StringValue);
						break;
					case SerialJoins.ComPort6:
						ProAvControlSystem.ComPorts[6].Send(args_.Sig.StringValue);
						break;
					case SerialJoins.ComPort7:
						ControlSystem.ExpansionCard.ComPorts[1].Send(args_.Sig.StringValue);
						break;
				}
			}
			if (args_.Sig.Type == eSigType.Bool) {
				"EiscBoolData [{0}]: {1}".PrintLine(args_.Sig.Number, args_.Sig.BoolValue);
				switch (args_.Sig.Number) {
					case BoolJoins.Relay1:
						if (args_.Sig.BoolValue) {
							ProAvControlSystem.ControlSystem.RelayPorts[1].Close();
						}
						else {
							ProAvControlSystem.ControlSystem.RelayPorts[1].Open();
						}
						break;
					case BoolJoins.Relay2:
						if (args_.Sig.BoolValue) {
							ProAvControlSystem.ControlSystem.RelayPorts[2].Close();
						}
						else {
							ProAvControlSystem.ControlSystem.RelayPorts[2].Open();
						}
						break;
					case BoolJoins.Relay3:
						if (args_.Sig.BoolValue) {
							ProAvControlSystem.ControlSystem.RelayPorts[3].Close();
						}
						else {
							ProAvControlSystem.ControlSystem.RelayPorts[3].Open();
						}
						break;
					case BoolJoins.Relay4:
						if (args_.Sig.BoolValue) {
							ProAvControlSystem.ControlSystem.RelayPorts[4].Close();
						}
						else {
							ProAvControlSystem.ControlSystem.RelayPorts[4].Open();
						}
						break;
					case BoolJoins.Relay5:
						if (args_.Sig.BoolValue) {
							ProAvControlSystem.ControlSystem.RelayPorts[5].Close();
						}
						else {
							ProAvControlSystem.ControlSystem.RelayPorts[5].Open();
						}
						break;
					case BoolJoins.Relay6:
						if (args_.Sig.BoolValue) {
							ProAvControlSystem.ControlSystem.RelayPorts[6].Close();
						}
						else {
							ProAvControlSystem.ControlSystem.RelayPorts[6].Open();
						}
						break;
					case BoolJoins.Relay7:
						if (args_.Sig.BoolValue) {
							ProAvControlSystem.ControlSystem.RelayPorts[7].Close();
						}
						else {
							ProAvControlSystem.ControlSystem.RelayPorts[7].Open();
						}
						break;
					case BoolJoins.Relay8:
						if (args_.Sig.BoolValue) {
							ProAvControlSystem.ControlSystem.RelayPorts[8].Close();
						}
						else {
							ProAvControlSystem.ControlSystem.RelayPorts[8].Open();
						}
						break;
					case BoolJoins.WestAwningOpen:
						if (args_.Sig.BoolValue) {
							ControlSystem.WestAwning.Open();
						}
						break;
					case BoolJoins.WestAwningClose:
						if (args_.Sig.BoolValue) {
							ControlSystem.WestAwning.Close();
						}
						break;
					case BoolJoins.WestAwningStop:
						if (args_.Sig.BoolValue) {
							ControlSystem.WestAwning.Stop();
						}
						break;
				}
			}
			if (args_.Sig.Type == eSigType.UShort) {
				"EiscUShortData [{0}]: {1}".PrintLine(args_.Sig.Number, args_.Sig.UShortValue);
				switch (args_.Sig.Number) {
					default:
						"Eisc Ushort Input has no joins registered".PrintLine();
						break;
				}
			}
		}
	}
}