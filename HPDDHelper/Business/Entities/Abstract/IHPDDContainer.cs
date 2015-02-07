using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HPDDHelper.Business.Entities.Abstract
{
    public interface IHPDDContainer
    {
        IEnumerable<IHPDDElement> GetChildren();

        void AddChild(IHPDDElement child);
    }
}
