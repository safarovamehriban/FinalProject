﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Exceptions
{
    public class FileNullReferenceException : Exception

    {
        public FileNullReferenceException(string? message) : base(message)
        {

        }

    }
}
