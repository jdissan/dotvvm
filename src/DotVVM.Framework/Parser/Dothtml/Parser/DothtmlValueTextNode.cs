﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotVVM.Framework.Parser.Dothtml.Parser
{
    public class DothtmlValueTextNode : DothtmlValueNode
    {
        public Tokenizer.DothtmlToken ValueToken { get; set; }
        public string Text => ValueToken.Text;
    }
}
