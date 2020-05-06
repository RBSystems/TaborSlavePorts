﻿using System;
using System.Collections.Generic;
using Crestron.SimplSharpPro;
using Crestron.SimplSharpPro.ThreeSeriesCards;
using Crestron.SimplSharpProInternal;
using proAV.Core;
using proAV.Core.Extensions;
using proAV.Devices.Lifts.FutureAutomation;
using proAV.Devices.RadioTuners.Rotel;

namespace TaborSlavePorts {
	public class SystemInitialiser {

		public SystemInitialiser() {
			this.PrintFunctionName("Initialisation started");
			var systemInitialisationActions = new List<Action>{
				CreateEisc,
				RegisterInternalComports,
				RegisterExpansionComports,
				RegisterInternalRelayPorts,
				RegisterAndSetIoPorts
			};
			BootManager.BootFunctions.AddRange(systemInitialisationActions);
			foreach (var bootFunction in BootManager.BootFunctions) {
				var index = BootManager.BootFunctions.IndexOf(bootFunction);
				bootFunction();
				BootManager.WriteBootPositionToConsole(index + 1);
			}
		}

		private void CreateEisc(){
			this.PrintFunctionName("CreateEISC");
			var eiscHandler = new EiscHandler();
			ControlSystem.MasterProcessorLink = eiscHandler.Create();
			var listener = new EiscListener();
		}

		private void RegisterInternalComports(){
			this.PrintFunctionName("RegisterInternalComports");
			foreach (var comPort in ProAvControlSystem.ComPorts){
				comPort.Value.SetComPortSpec(RotelSerialSpec.Spec());
				comPort.Value.Register();
			}
			var listener = new ComportListener();
		}

		private void RegisterExpansionComports(){
			this.PrintFunctionName("RegisterExpansionComports");
			var card = new C3com3(2, ProAvControlSystem.ControlSystem);
			card.Register();
			card.ComPorts[1].SetComPortSpec(FutureAutomationProjectorDropSerialSpec.Spec());
			card.ComPorts[1].Register();
			ControlSystem.ExpansionCard = card;
		}

		private void RegisterInternalRelayPorts(){
			this.PrintFunctionName("RegisterRelayPorts");
			foreach (var relay in ProAvControlSystem.ControlSystem.RelayPorts){
				relay.Register();
			}
		}

		private void RegisterAndSetIoPorts(){
			this.PrintFunctionName("RegisterAndSetIoPorts");
			foreach (var versiport in ProAvControlSystem.ControlSystem.VersiPorts){
				versiport.Register();
				versiport.SetVersiportConfiguration(eVersiportConfiguration.DigitalInput);
			}
			var listener = new IoListener();
		}
	}
}