﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileExplorer.Models
{
    public class Tabulator
    {
        public Tabulator(string name)
        {
            Name = name;
        }

        public string Name { get; set; }
    }
}
