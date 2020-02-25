﻿
//===============================================================================
//
//  IMPORTANT NOTICE, PLEASE READ CAREFULLY:
//
//  => This code is licensed under the GNU General Public License (GPL v3). A copy of the license is available at:
//        https://www.gnu.org/licenses/gpl.txt
//
//  => As stated in the license text linked above, "The GNU General Public License does not permit incorporating your program into proprietary programs". It also does not permit incorporating this code into non-GPL-licensed code (such as MIT-licensed code) in such a way that results in a non-GPL-licensed work (please refer to the license text for the precise terms).
//
//  => Licenses that permit proprietary use are available at:
//        http://www.cshtml5.com
//
//  => Copyright 2019 Userware/CSHTML5. This code is part of the CSHTML5 product (cshtml5.com).
//
//===============================================================================



using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace System.ComponentModel
{
    public partial class AsyncCompletedEventArgs : EventArgs
    {
        public AsyncCompletedEventArgs(Exception error, bool cancelled, object userState)
        {
            this.error = error;
            this.cancelled = cancelled;
            this.userState = userState;
        }

        public bool Cancelled { get { return cancelled; } }
        private readonly bool cancelled;

        private Exception error;
        public Exception Error { get { return error; } }

        private object userState;
        public object UserState { get { return userState; } }

        protected void RaiseExceptionIfNecessary()
        {
            if (Error != null)
            {
                throw new TargetInvocationException("Exception Occurred", Error);
            }
            else if (Cancelled)
            {
                throw new InvalidOperationException("Operation Cancelled");
            }
        }

    }
}
