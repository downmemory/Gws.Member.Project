using System.Data;

namespace Gws.Common.Models.Internal
{
    public class ServiceWrapper<T>
    {
        public T Service {get; set;}
        public DateTime CreateDateTime { get; set; }
        public ServiceWrapper(T value)
        {
            Service= value;
            CreateDateTime = DateTime.Now;
        }
    }


}