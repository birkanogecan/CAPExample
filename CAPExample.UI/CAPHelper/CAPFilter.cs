using DotNetCore.CAP.Filter;

namespace CAPExample.UI
{
    public class CAPFilter : SubscribeFilter
    {
        public override void OnSubscribeExecuting(ExecutingContext context)
        {
            // before subscribe method exectuing
        }

        public override void OnSubscribeExecuted(ExecutedContext context)
        {
            // after subscribe method executed
        }

        public override void OnSubscribeException(ExceptionContext context)
        {
            // subscribe method execution exception
        }
    }
}
