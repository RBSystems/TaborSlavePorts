using Crestron.SimplSharpPro;
using proAV.Core.Framework;

namespace TaborSlavePorts {
	public class SomfyRelayAwning {
		protected Relay OpenRelay;
		protected Relay CloseRelay;
		private readonly ProAvRelay _openR;
		private readonly ProAvRelay _closeR;

		public SomfyRelayAwning(IRelayPorts device_, uint openRelay_, uint closeRelay_) {
			OpenRelay = device_.RelayPorts[openRelay_];
			CloseRelay = device_.RelayPorts[closeRelay_];
			OpenRelay.Register();
			CloseRelay.Register();

			_openR = new ProAvRelay(OpenRelay) { PulseCloseOpen = true };
			_closeR = new ProAvRelay(CloseRelay) { PulseCloseOpen = true };
		}

		public void Open() {
			_openR.Pulse();
		}

		public void Close() {
			_closeR.Pulse();
		}

		public void Stop() {
			_openR.Pulse();
			_closeR.Pulse();
		}
	}
}