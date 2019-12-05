using System;
using System.Reflection;

namespace Servicio_Web_REST_y_Entiy_Framwork_MOTOS.Areas.HelpPage.ModelDescriptions
{
    public interface IModelDocumentationProvider
    {
        string GetDocumentation(MemberInfo member);

        string GetDocumentation(Type type);
    }
}