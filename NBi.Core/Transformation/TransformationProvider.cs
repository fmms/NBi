﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NBi.Core.Transformation
{
    public class TransformationProvider
    {
        private IDictionary<int, ITransformer> cacheTransformers;
        private readonly TransformerFactory factory;

        public TransformationProvider()
        {
            cacheTransformers = new Dictionary<int, ITransformer>();
            factory = new TransformerFactory();
        }

        public void Add(int columnIndex, ITransformationInfo transfo)
        {
            var transformer = factory.Build(transfo);
            transformer.Initialize(transfo.Code);
            cacheTransformers.Add(columnIndex, transformer);
        }

        public void Transform(NBi.Core.ResultSet.ResultSet resultSet)
        {
            foreach (var index in cacheTransformers.Keys)
            {
                var tsStart = DateTime.Now;
                var transformer = cacheTransformers[index];
                foreach (DataRow row in resultSet.Table.Rows)
                    row[index] = transformer.Execute(row[index]);
                Trace.WriteLineIf(NBiTraceSwitch.TraceInfo, string.Format("Time needed to transform column with index {0}: {0}", index, DateTime.Now.Subtract(tsStart).ToString(@"d\d\.hh\h\:mm\m\:ss\s\ \+fff\m\s")));
            }
        }
    }
}
