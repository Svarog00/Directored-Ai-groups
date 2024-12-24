using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InteractableGroupsAi.Agents
{
    public abstract class Sensor
    {
        public Action<IAgentContext> OnAgentDetected { get; set; }
        public Action<IAgentContext> OnAgentLost { get; set; }

        public abstract void Update();
    }
}
