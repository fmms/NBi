﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NBi.Extensibility.DataEngineering
{
    public interface IEtlRunnerFactory
    {
        IEtlRunner Instantiate(IEtlArgs args);
    }
}
