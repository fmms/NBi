﻿using NBi.Extensibility;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NBi.Core.IO.Filtering
{
    public class PatternRootFilter : IRootFileFilter
    {
        public string Value { get; }
        public PatternRootFilter(string value) => Value = value;

        public FileInfo[] Execute(string path)
        {
            var dir = new DirectoryInfo(path);

            if (!dir.Exists)
                throw new ExternalDependencyNotFoundException(path);

            return dir.GetFiles(Value, SearchOption.TopDirectoryOnly);
        }
    }
}
