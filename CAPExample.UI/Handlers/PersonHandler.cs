using CAPExample.UI.Events;
using DotNetCore.CAP;

namespace CAPExample.UI
{
    public class PersonHandler : ICapSubscribe
    {

        [CapSubscribe(nameof(PersonCreated))]
        public void ConsumeTest([FromCap] CapHeader h, PersonCreated p)
        {
            //int id = @eventPayLoad.Id;
            //string name = p.Name;
        }

    }
}
