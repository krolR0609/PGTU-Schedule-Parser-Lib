using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParseLib.Models
{
    public class ValuePair : ITypeValue
    {
        public string Value { get; set; }
        public string Type { get; set; }

        public ValuePair()
        {
            this.Value = "Value";
            this.Type = "Type";
        }
        public ValuePair(string type, string value)
        {
            this.Value = value;
            this.Type = type;
        }

        public override string ToString()
        {
            return $"Value: {Value}, Type: {Type}";
        }
    }
}
