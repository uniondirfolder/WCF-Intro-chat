using System.ServiceModel;

namespace chat_cl
{
    public class EntityUser
    {
        public EntityUser(int id, string name, OperationContext operationContext)
        {
            Id = id;
            Name = name;
            OperationContext = operationContext;
        }

        public int Id { get; }
        public string Name { get; }
        public OperationContext OperationContext { get; }
    }
}