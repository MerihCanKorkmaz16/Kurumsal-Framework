using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KurumsalFramework.Northwind.Entities.ComplexType
{
    public class ProductDetail
    {
        //nhibernate çalışacağımı düşündüğüm için virtual yazdım
        public virtual int ProductId { get; set; }
        public virtual string ProductName { get; set; }
        public virtual string CategoryName { get; set; }
    }
}
