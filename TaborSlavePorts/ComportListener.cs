using Crestron.SimplSharpPro;
using proAV.Core;

namespace TaborSlavePorts {
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
					ControlSystem.MasterProcessorLink.StringInput[SerialJoins.ComPort1Rx].StringValue = args_.SerialData;
					break;
				case 2:
					ControlSystem.MasterProcessorLink.StringInput[SerialJoins.ComPort2Rx].StringValue = args_.SerialData;
					break;
				case 3:
					ControlSystem.MasterProcessorLink.StringInput[SerialJoins.ComPort3Rx].StringValue = args_.SerialData;
					break;
				case 4:
					ControlSystem.MasterProcessorLink.StringInput[SerialJoins.ComPort4Rx].StringValue = args_.SerialData;
					break;
				case 5:
					ControlSystem.MasterProcessorLink.StringInput[SerialJoins.ComPort5Rx].StringValue = args_.SerialData;
					break;
				case 6:
					ControlSystem.MasterProcessorLink.StringInput[SerialJoins.ComPort6Rx].StringValue = args_.SerialData;
					break;
			}
		}

		private static void ExpansionComportOnSerialDataReceived(ComPort receivingComPort_, ComPortSerialDataEventArgs args_) {
			switch (receivingComPort_.ID){
				case 1:
					ControlSystem.MasterProcessorLink.StringInput[SerialJoins.ComPort7Rx].StringValue = args_.SerialData;
					break;
			}
		}
	}
}