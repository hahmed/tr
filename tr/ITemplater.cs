using System;
using System.ServiceModel;
using tr.Models;

namespace tr
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "ITemplater" in both code and config file together.
    [ServiceContract]
    public interface ITemplater
    {
        [OperationContract]
        TemplateResponse Render(RenderingOptions options);
    }
}