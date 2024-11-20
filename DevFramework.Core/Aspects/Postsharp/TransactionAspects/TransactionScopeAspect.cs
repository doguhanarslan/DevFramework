using System.Transactions;
using PostSharp.Aspects;
using PostSharp.Serialization;

namespace DevFramework.Core.Aspects.Postsharp.TransactionAspects
{
    [PSerializable]
    public class TransactionScopeAspect:OnMethodBoundaryAspect
    {
        public TransactionScopeOption _option;
       
        public TransactionScopeAspect(TransactionScopeOption option)
        {
            _option = option;
        }

        public TransactionScopeAspect()
        {
            
        }

        public override void OnEntry(MethodExecutionArgs args)
        {
            args.MethodExecutionTag = new TransactionScope(_option);
        }

        public override void OnSuccess(MethodExecutionArgs args)
        {
            ((TransactionScope)args.MethodExecutionTag).Complete();
        }


        public override void OnExit(MethodExecutionArgs args)
        {
            ((TransactionScope)args.MethodExecutionTag).Dispose();
        }
    }
}
