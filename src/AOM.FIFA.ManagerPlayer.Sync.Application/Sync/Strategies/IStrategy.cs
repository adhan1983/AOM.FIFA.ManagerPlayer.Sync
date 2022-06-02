using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AOM.FIFA.ManagerPlayer.Sync.Application.Sync.Strategies
{
    public interface IStrategy
    {
        object DoAlgorithm(object data);
    }
}
