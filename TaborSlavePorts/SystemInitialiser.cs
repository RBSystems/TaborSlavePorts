using System;
using System.Collections.Generic;
using Crestron.SimplSharpPro;
using Crestron.SimplSharpPro.ThreeSeriesCards;
using proAV.Core;
using proAV.Core.Devices.Lifts.FutureAutomation;
using proAV.Core.Devices.RadioTuners.Rotel;
using proAV.Core.Extensions;
using TaborSlavePorts.PortListeners;
using proAV.Core.Devices.Lexicon;

namespace TaborSlavePorts {
	public class SystemInitialiser {
		public SystemInitialiser() {
			this.PrintFunctionName("Initialisation started");
			var systemInitialisationActions = new List<Action>{
				CreateMc4Eisc,
				Comports,
				Com3Comports,
				Relays,
				Ios,
				CreateSomfyController
			};
			BootManager.BootFunctions.AddRange(systemInitialisationActions);
			foreach (var bootFunction in BootManager.BootFunctions) {
				var index = BootManager.BootFunctions.IndexOf(bootFunction);
				bootFunction();
				BootManager.WriteBootPositionToConsole(index + 1);
			}
		}

		private void CreateMc4Eisc() {
			this.PrintFunctionName("CreateEISC");
			var eiscHandler = new Mc4EiscFactory();
			ControlSystem.MasterProcessorLink = eiscHandler.Create();
			var listener = new EiscListener();
		}

		#region Processor Ports

		private void Comports() {
			this.PrintFunctionName("Comports");
			foreach (var comPort in ProAvControlSystem.ComPorts) {
				comPort.Value.Register();
				comPort.Value.SetComPortSpec(RotelSerialSpec.Spec());
			}
		}

		private void Com3Comports() {
			this.PrintFunctionName("Com3Comports");
			var card = new C3com3(1, ProAvControlSystem.ControlSystem);
			foreach (var comport in card.ComPorts) {
				comport.Register();
			}
			card.Register();
			card.ComPorts[1].SetComPortSpec(LexiconSerialSpec.Spec());
			ControlSystem.ExpansionCard = card;
		}

		private void Relays() {
			this.PrintFunctionName("Relays");
			foreach (var relay in ProAvControlSystem.ControlSystem.RelayPorts) {
				relay.Register();
			}
		}

		private void Ios() {
			this.PrintFunctionName("Ios");
			foreach (var versiport in ProAvControlSystem.ControlSystem.VersiPorts) {
				versiport.Register();
				versiport.SetVersiportConfiguration(eVersiportConfiguration.DigitalInput);
			}
		}

		#endregion

		private void CreateSomfyController() {
			ControlSystem.WestAwning = new SomfyRelayAwning(ProAvControlSystem.ControlSystem, 1, 2);
		}
	}
}