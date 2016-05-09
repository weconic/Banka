using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Windows.Data;
using System.Data;
using System.IO;
using System.Xml.Serialization;
using System.Xml;

namespace SantaElizabeteKarklina
{


    public class MainWindowViewModel
    {
        public static DocumentElement ParsedObject {get; set;}
        public ICollectionView Customers { get; private set; }
        public ICollectionView GroupedCustomers { get; private set; }
        public int CustomerCount { get; set; }

        protected T FromXml<T>(String xml)
        {
            T returnedXmlClass = default(T);

            try
            {
                using (TextReader reader = new StringReader(xml))
                {
                    try
                    {
                        returnedXmlClass =
                            (T)new XmlSerializer(typeof(T)).Deserialize(reader);
                    }
                    catch (InvalidOperationException)
                    {
                        // String passed is not XML, simply return defaultXmlClass
                    }
                }
            }
            catch (Exception ex)
            {
            }

            return returnedXmlClass;
        }

        public MainWindowViewModel()
        {
            DataSet ds = new DataSet();
            ds.ReadXml("try.xml");

            Customers = CollectionViewSource.GetDefaultView(ds.Tables[0]);

            CustomerCount = GetCustomerCount();
        }

        public MainWindowViewModel(string filter)
        {
            DataSet ds = new DataSet();
            ds.ReadXml("try.xml");

            Customers = CollectionViewSource.GetDefaultView(ds.Tables[0]);

            CustomerCount = GetCustomerCount();
        }

        private int GetCustomerCount()
        {
            var i = 0;

            do
            {
                i++;
            }
            while (Customers.MoveCurrentToNext());

            return i;
        }
    }
}