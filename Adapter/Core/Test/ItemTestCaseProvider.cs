using System;
using System.Collections;
using System.Collections.Generic;
using NUnit.Framework.Interfaces;

namespace Adapter.Core.Test
{
    public abstract class ItemTestCaseProvider : IEnumerable<ITestCaseData>
    {
        public virtual IEnumerator<ITestCaseData> GetEnumerator()
        {
            yield return null;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}

