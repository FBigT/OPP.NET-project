using FifaLib.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FifaLib {
    public interface IRepo {
        T GetData<T>(Gender gender, DataSource source);
    }
}
