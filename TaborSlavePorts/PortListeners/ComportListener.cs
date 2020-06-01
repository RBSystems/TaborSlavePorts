using Crestron.SimplSharpPro;
using proAV.Core;
using proAV.Core.Extensions;

namespace TaborSlavePorts.PortListeners {
	public class ComportListener {
		public ComportListener(){
			foreach (var comport in ProAvControlSystem.ControlSystem.ComPorts){
				comport.SerialDataReceived += ComportOnSerialDataReceived;
			}
			foreach (var comport in ControlSystem.ExpansionCard.ComPorts) {
				comport.SerialDataReceived += ExpansionComportOnSerialDataReceived;
			}
		}

		private static void ComportOnSerialDataReceived(ComPort receivingComPort_, ComPortSerialDataEventArgs args_){
			switch (receivingComPort_.ID){
				case 1:
					"Outgoing >>> EiscSerialData [{0}]: {1}".PrintLine(SerialJoins.ComPort1, args_.SerialData);
					ControlSystem.MasterProcessorLink.StringInput[SerialJoins.ComPort1].StringValue = args_.SerialData;
					break;
				case 2:
					"Outgoing >>> EiscSerialData [{0}]: {1}".PrintLine(SerialJoins.ComPort2, args_.SerialData);
					ControlSystem.MasterProcessorLink.StringInput[SerialJoins.ComPort2].StringValue = args_.SerialData;
					break;
				case 3:
					"Outgoing >>> EiscSerialData [{0}]: {1}".PrintLine(SerialJoins.ComPort3, args_.SerialData);
					ControlSystem.MasterProcessorLink.StringInput[SerialJoins.ComPort3].StringValue = args_.SerialData;
					break;
				case 4:
					"Outgoing >>> EiscSerialData [{0}]: {1}".PrintLine(SerialJoins.ComPort4, args_.SerialData);
					ControlSystem.MasterProcessorLink.StringInput[SerialJoins.ComPort4].StringValue = args_.SerialData;
					break;
				case 5:
					"Outgoing >>> EiscSerialData [{0}]: {1}".PrintLine(SerialJoins.ComPort5, args_.SerialData);
					ControlSystem.MasterProcessorLink.StringInput[SerialJoins.ComPort5].StringValue = args_.SerialData;
					break;
				case 6:
					"Outgoing >>> EiscSerialData [{0}]: {1}".PrintLine(SerialJoins.ComPort6, args_.SerialData);
					ControlSystem.MasterProcessorLink.StringInput[SerialJoins.ComPort6].StringValue = args_.SerialData;
					break;
			}
		}

		private static void ExpansionComportOnSerialDataReceived(ComPort receivingComPort_, ComPortSerialDataEventArgs args_) {
			switch (receivingComPort_.ID){
				case 1:
					"Outgoing >>> EiscSerialData [{0}]: {1}".PrintLine(SerialJoins.ComPort7, args_.SerialData);
					ControlSystem.MasterProcessorLink.StringInput[SerialJoins.ComPort7].StringValue = args_.SerialData;
					break;
			}
		}
	}
}