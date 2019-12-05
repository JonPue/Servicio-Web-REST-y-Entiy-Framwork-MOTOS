using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Servicio_Web_REST_y_Entiy_Framwork_MOTOS.Areas.HelpPage.ModelDescriptions
{
    public class EnumTypeModelDescription : ModelDescription
    {
        public EnumTypeModelDescription()
        {
            Values = new Collection<EnumValueDescription>();
        }

        public Collection<EnumValueDescription> Values { get; private set; }
    }
}