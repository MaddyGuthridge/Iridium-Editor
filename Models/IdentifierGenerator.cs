using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IridiumEditor.Models
{
    class IdentifierGenerator
    {
        private readonly HashSet<int> _prevValues;
        private readonly Random _generator;
        public IdentifierGenerator()
        {
            // Create hash set and add zero to it
            _prevValues = new HashSet<int> { 0 };
            // Create random generator
            _generator = new Random();
        }

        public int GetNewValue()
        {
            int ret = 0;
            // Generate values
            while (_prevValues.Contains(ret))
            {
                ret = _generator.Next();
            }
            _prevValues.Add(ret);
            return ret;
        }
    }
}
