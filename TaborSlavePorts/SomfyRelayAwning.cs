using Crestron.SimplSharpPro;
using proAV.Core.Devices.Blinds;
using proAV.Core.Framework;

namespace TaborSlavePorts {
	public class SomfyRelayAwning : CrestronRelayControlledMotor {
		private ProAvRelay OpenR;
		private ProAvRelay CloseR;

		public SomfyRelayAwning(IRelayPorts device_, uint openRelay_, uint closeRelay_)
			: base(device_, openRelay_, closeRelay_) {
			OpenR = new ProAvRelay(OpenRelay);
			OpenR.PulseCloseOpen = true;
			CloseR = new ProAvRelay(CloseRelay);
			CloseR.PulseCloseOpen = true;
		}

		public void Open() {
			OpenR.Pulse();
		}

		public void Close() {
			CloseR.Pulse();
		}

		public void Stop() {
			OpenR.Pulse();
			CloseR.Pulse();
		}
	}
}