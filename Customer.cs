using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace SantaElizabeteKarklina
{
    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "", IsNullable = false)]
    public partial class DocumentElement
    {

        private DocumentElementCustomer[] customerField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("customer")]
        public DocumentElementCustomer[] customer
        {
            get
            {
                return this.customerField;
            }
            set
            {
                this.customerField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class DocumentElementCustomer
    {

        private string accountNumberField;

        private string nameField;

        private string surnameField;

        private decimal accountBalanceField;

        private System.DateTime accountOpenDateField;

        /// <remarks/>
        public string accountNumber
        {
            get
            {
                return this.accountNumberField;
            }
            set
            {
                this.accountNumberField = value;
            }
        }

        /// <remarks/>
        public string name
        {
            get
            {
                return this.nameField;
            }
            set
            {
                this.nameField = value;
            }
        }

        /// <remarks/>
        public string surname
        {
            get
            {
                return this.surnameField;
            }
            set
            {
                this.surnameField = value;
            }
        }

        /// <remarks/>
        public decimal accountBalance
        {
            get
            {
                return this.accountBalanceField;
            }
            set
            {
                this.accountBalanceField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "date")]
        public System.DateTime accountOpenDate
        {
            get
            {
                return this.accountOpenDateField;
            }
            set
            {
                this.accountOpenDateField = value;
            }
        }
    }
}