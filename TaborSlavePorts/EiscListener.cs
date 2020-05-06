using Crestron.SimplSharpPro;
using Crestron.SimplSharpPro.DeviceSupport;
using proAV.Core;
using proAV.Core.Extensions;

namespace TaborSlavePorts{
	public class EiscListener{
		public EiscListener(){
			ControlSystem.MasterProcessorLink.SigChange += MasterProcessorLinkOnSigChange;
		}

		private static void MasterProcessorLinkOnSigChange(BasicTriList currentDevice_, SigEventArgs args_){
			if (args_.Sig.Type == eSigType.String){
				switch (args_.Sig.Number){
					case SerialJoins.ComPort1Tx:
						ProAvControlSystem.ComPorts[1].Send(args_.Sig.StringValue);
						break;
					case SerialJoins.ComPort2Tx:
						ProAvControlSystem.ComPorts[2].Send(args_.Sig.StringValue);
						break;
					case SerialJoins.ComPort3Tx:
						ProAvControlSystem.ComPorts[3].Send(args_.Sig.StringValue);
						break;
					case SerialJoins.ComPort4Tx:
						ProAvControlSystem.ComPorts[4].Send(args_.Sig.StringValue);
						break;
					case SerialJoins.ComPort5Tx:
						ProAvControlSystem.ComPorts[5].Send(args_.Sig.StringValue);
						break;
					case SerialJoins.ComPort6Tx:
						ProAvControlSystem.ComPorts[6].Send(args_.Sig.StringValue);
						break;
					case SerialJoins.ComPort7Tx:
						ControlSystem.ExpansionCard.ComPorts[1].Send(args_.Sig.StringValue);
						break;
				}
			}
			if (args_.Sig.Type == eSigType.Bool){
				switch (args_.Sig.Number){
					case BoolJoins.Relay1Close:
						ProAvControlSystem.ControlSystem.RelayPorts[1].Close();
						break;
					case BoolJoins.Relay1Open:
						ProAvControlSystem.ControlSystem.RelayPorts[1].Open();
						break;
					case BoolJoins.Relay2Close:
						ProAvControlSystem.ControlSystem.RelayPorts[2].Close();
						break;
					case BoolJoins.Relay2Open:
						ProAvControlSystem.ControlSystem.RelayPorts[2].Open();
						break;
					case BoolJoins.Relay3Close:
						ProAvControlSystem.ControlSystem.RelayPorts[3].Close();
						break;
					case BoolJoins.Relay3Open:
						ProAvControlSystem.ControlSystem.RelayPorts[3].Open();
						break;
					case BoolJoins.Relay4Close:
						ProAvControlSystem.ControlSystem.RelayPorts[4].Close();
						break;
					case BoolJoins.Relay4Open:
						ProAvControlSystem.ControlSystem.RelayPorts[4].Open();
						break;
					case BoolJoins.Relay5Close:
						ProAvControlSystem.ControlSystem.RelayPorts[5].Close();
						break;
					case BoolJoins.Relay5Open:
						ProAvControlSystem.ControlSystem.RelayPorts[5].Open();
						break;
					case BoolJoins.Relay6Close:
						ProAvControlSystem.ControlSystem.RelayPorts[6].Close();
						break;
					case BoolJoins.Relay6Open:
						ProAvControlSystem.ControlSystem.RelayPorts[6].Open();
						break;
					case BoolJoins.Relay7Close:
						ProAvControlSystem.ControlSystem.RelayPorts[7].Close();
						break;
					case BoolJoins.Relay7Open:
						ProAvControlSystem.ControlSystem.RelayPorts[7].Open();
						break;
					case BoolJoins.Relay8Close:
						ProAvControlSystem.ControlSystem.RelayPorts[8].Close();
						break;
					case BoolJoins.Relay8Open:
						ProAvControlSystem.ControlSystem.RelayPorts[8].Open();
						break;
				}
			}
			if (args_.Sig.Type == eSigType.UShort){
				switch (args_.Sig.Number){
					default:
					"Eisc Ushort Input has no joins registered".PrintLine();
						break;
				}
			}
		}
	}
}