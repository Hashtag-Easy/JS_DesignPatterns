using System;

namespace DesignPatterns.Samples.Patterns
{
    internal interface IDataSource
    {
        void WriteData(object data);
        object ReadData();
    }
    internal class FileDataSource : IDataSource
    {
        public object ReadData()
        {
            //TODO
            Console.WriteLine("Reads data from a file");
            return null;
        }

        public void WriteData(object data)
        {
            Console.WriteLine("Writes a data to a file");
            //TODO
        }
    }


    internal abstract class DataSourceDecorator : IDataSource
    {
        private IDataSource _wrapee;

            public DataSourceDecorator(IDataSource wrapee) 
        { _wrapee = wrapee; }

        public virtual object ReadData()
        {
            return _wrapee.ReadData();
        }

        public virtual void WriteData(object data)
        {
            _wrapee.WriteData(data);
        }
    }

    internal class EncryptionDecorator : DataSourceDecorator
    {
        public EncryptionDecorator(IDataSource wrapee) : base(wrapee) {}

        public override void WriteData(object data)
        {
            //Encypt data before write
            base.WriteData(data);
        }

        public override object ReadData()
        {
            //Decrypt data to read it
            return base.ReadData();
        }
    }


    internal class CompressionDecorator : DataSourceDecorator
    {
        public CompressionDecorator(IDataSource wrapee) : base(wrapee) { }

        public override void WriteData(object data)
        {
            //Compress data before write
            base.WriteData(data);
        }

        public override object ReadData()
        {
            //Decompress data to read it
            return base.ReadData();
        }
    }



    internal class TestDecorator
    {
        public void Test()
        {
            var encryptor = new EncryptionDecorator(new FileDataSource());
            var encrypAndCompress = new EncryptionDecorator(new CompressionDecorator(new FileDataSource()));
        }
    }
}
