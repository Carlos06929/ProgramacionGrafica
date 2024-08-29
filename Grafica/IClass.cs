using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grafica
{
    interface IClass
    {
        void setCenter(IClass center);
        IClass getElement(string name);
        void setElement();
        void deleteElement();
        void Draw();
    }
}
