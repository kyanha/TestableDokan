using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestableDokan.MockableDokan
{
    public class FileInformation : FileInformationBase
    {
        long _length;
        public override long Length { get => GetLength(); set => SetLength(value); }

        protected virtual long GetLength()
        {
            return _length;
        }

        protected virtual void SetLength(long value)
        {
            if (value < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(value), "Size cannot be negative");
            }
            _length = value;
        }
    }
}
