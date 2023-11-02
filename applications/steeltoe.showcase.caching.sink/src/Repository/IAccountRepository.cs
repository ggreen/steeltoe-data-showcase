using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Linq;
using Showcase.SteelToe.Data.Solutions.Domain;

namespace Steeltoe.Showcase.Caching.Sink.Repository
{
    public interface IAccountRepository
    {
        void Save(Account account);
    }
}