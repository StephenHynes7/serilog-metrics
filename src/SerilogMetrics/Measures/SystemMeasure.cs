////////////////////////////////////////////////////////////////////////////////
//
//  MATTBOLT.BLOGSPOT.COM
//  Copyright(C) 2013 Matt Bolt
//
//  Licensed under the Apache License, Version 2.0 (the "License");
//  you may not use this file except in compliance with the License.
//  You may obtain a copy of the License at:
//
//      http://www.apache.org/licenses/LICENSE-2.0
//
//  Unless required by applicable law or agreed to in writing, software
//  distributed under the License is distributed on an "AS IS" BASIS,
//  WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
//  See the License for the specific language governing permissions and
//  limitations under the License.
//
//////////////////////////////////////////////////////////////////////////////// 

// Copyright 2014 Serilog Contributors
// 
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
// 
//     http://www.apache.org/licenses/LICENSE-2.0
// 
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.


using Serilog;
using Serilog.Events;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SerilogMetrics.Measures
{
    /// <summary>
    /// Initializes a new instance of the <see cref="SystemMeasure"/> class.
    /// </summary>
    public class SystemMeasure : ISystemMeasure {

        readonly ILogger _logger;
        readonly string _name;
        readonly LogEventLevel _level;
        private float _value;
        private PerformanceCounter _performanceCounter;

        /// <summary>
        /// Initializes a new instance of the <see cref="SystemMeasure"/> class.
        /// </summary>
        public SystemMeasure(ILogger logger, LogEventLevel level, string name, PerformanceCounter performanceCounter)
        {
            _logger = logger;
            _name = name;
            _level = level;
            _value = 0;
            _performanceCounter = performanceCounter;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="SystemMeasure"/> class.
        /// </summary>
        public virtual void Start()
        {
            _value = (long)_performanceCounter.NextValue();
            Write();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="SystemMeasure"/> class.
        /// </summary>
        public virtual void Stop()
        {
            _value = 0;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="SystemMeasure"/> class.
        /// </summary>
        public virtual void Write()
        {
            _logger.Write(_level, _name, _value);
        }
    }
}
