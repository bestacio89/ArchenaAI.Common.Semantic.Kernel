namespace ArchenaAI.Common.Semantic.Kernel.Messaging.Agents
{
    public static class AgentMessageType
    {
        public const string Request = "agent.request";
        public const string Response = "agent.response";
        public const string Error = "agent.error";
        public const string Think = "agent.think";
        public const string Act = "agent.act";
        public const string Reflect = "agent.reflect";
        public const string MemoryUpdate = "agent.memory.update";
    }
}
