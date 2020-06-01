using System;
using System.Collections.Generic;
using Crestron.SimplSharp.Reflection;
using Crestron.SimplSharpPro.CrestronThread;
using Crestron.SimplSharpPro.EthernetCommunication;
using Crestron.SimplSharpPro.ThreeSeriesCards;
using proAV.Core;
using proAV.Core.Utilities;
using TaborSlavePorts.PortListeners;

namespace TaborSlavePorts {
	public class ControlSystem : ProAvControlSystem{
		public Thread ProgramThread;
		public ControlSystem() : base(Assembly.GetExecutingAssembly(), 300){}
		public List<Thread> ProgramThreads { get; set; }
		public static EthernetIntersystemCommunications MasterProcessorLink { get; set; }
		public static C3com3 ExpansionCard { get; set; }
		public static SomfyRelayAwning WestAwning;

		private ComportListener _comportListener;
		private IoListener _ioListener;

		public override void Initialise(){
			ProgramUpdateChecker.AutoUpdateProgram = true;
			ProgramThreads = new List<Thread>();
			ProgramThreads.Add(ProgramThread = new Thread(StartProgram, null, Thread.eThreadStartOptions.Running));
			Program.ProgramStopTriggered += ProgramStopTriggered;
			AddProjectConsoleCommands();
		}

		public object StartProgram(object _) {
			var systemInitialiser = new SystemInitialiser();
			_comportListener = new ComportListener();
			_ioListener = new IoListener();

			BootManager.BootComplete();
			return null;
		}

		private void ProgramStopTriggered(object sender_, EventArgs eventArgs_){
			if (ProgramThreads.Count <= 0){
				return;
			}
			ProgramThreads.ForEach(thread_ => thread_.Join());
		}

		private void AddProjectConsoleCommands(){}
	}
}